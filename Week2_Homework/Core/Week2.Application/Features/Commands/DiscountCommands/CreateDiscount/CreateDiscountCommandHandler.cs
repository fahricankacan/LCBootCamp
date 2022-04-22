using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Commands.DiscountCommands.CreateDiscount
{

    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommandRequest, CreateDiscountCommandResponse>
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IDiscountWriteRepository _discountWriteRepository;

        public CreateDiscountCommandHandler(IDiscountWriteRepository discountWriteRepository, IDiscountReadRepository discountReadRepository)
        {
            _discountWriteRepository = discountWriteRepository;
            _discountReadRepository = discountReadRepository;
        }

        public async Task<CreateDiscountCommandResponse> Handle(CreateDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            var d = _discountReadRepository.GetSingleAsync(p => p.Name == request.Name);

            if (d is not null)
            {
                return new CreateDiscountCommandResponse
                {
                    Message = "Discount is exist",
                    Success = false
                };
            }

            var id = Guid.NewGuid();
            Discount discount = new Discount
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                DiscountPercent = request.DiscountPercent,
                IsActive = request.IsActive
            };

            var result = await _discountWriteRepository.AddAsync(discount);

            return new CreateDiscountCommandResponse
            {
                Message = result ? "Successfully Added." : "Error while adding.",
                Success = result
            };

        }
    }

}
