using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;

namespace Week2.Application.Features.Commands.DiscountCommands.UpadateDiscount
{

    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommandRequest, UpdateDiscountCommandResponse>
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IDiscountWriteRepository _discountWriteRepository;

        public UpdateDiscountCommandHandler(IDiscountWriteRepository discountWriteRepository, IDiscountReadRepository discountReadRepository)
        {
            _discountWriteRepository = discountWriteRepository;
            _discountReadRepository = discountReadRepository;
        }

        public async Task<UpdateDiscountCommandResponse> Handle(UpdateDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            var discount = await _discountReadRepository.GetByIdAsync(request.Id);

            if (discount is null)
            {
                return new UpdateDiscountCommandResponse()
                {
                    Success = false,
                    Message = "Discount not found"
                };
            }

            var requestNameIsExist =await _discountReadRepository.GetSingleAsync(p => p.Name != request.Name) == null ? true : false;

            if (requestNameIsExist)
            {
                return new UpdateDiscountCommandResponse
                {
                    Message = "Discount name is exist",
                    Success = false
                };
            }

            if(request.IsActive is null && request.DiscountPercent is null && request.Name is null &&
                request.Description is null)
            {
                return new UpdateDiscountCommandResponse
                {
                    Success = false,
                    Message = "There is no data to update"
                };
            }

            discount.Name = request.Name ?? discount.Name; //discount.Name != request.Name ? request.Name : discount.Name;
            discount.Description = request.Description ?? discount.Description;//discount.Description != request.Description ? request.Description : discount.Description;
            discount.DiscountPercent = request.DiscountPercent ?? discount.DiscountPercent; //discount.DiscountPercent != request.DiscountPercent ? request.DiscountPercent : discount.DiscountPercent;
            discount.IsActive = request.IsActive ?? discount.IsActive; //discount.IsActive != request.IsActive ? request.IsActive : discount.IsActive;

            _discountWriteRepository.Update(discount);            
            var result = await _discountWriteRepository.SaveAsync();

            return new UpdateDiscountCommandResponse()
            {
                Success = result == 1 ? true : false,
                Message = result == 1 ? "Discount updated successfully" : "Discount not updated"
            };
        }
    }

}
