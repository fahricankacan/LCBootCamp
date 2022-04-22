﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;

namespace Week2.Application.Features.Commands.DiscountCommands.DeleteDiscount
{

    public partial class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommandRequest, DeleteDiscountCommandResponse>
    {
        public readonly IDiscountWriteRepository _discountWriteRepository;
        public readonly IDiscountReadRepository _discountReadRepository;

        public DeleteDiscountCommandHandler(IDiscountWriteRepository discountWriteRepository, IDiscountReadRepository discountReadRepository)
        {
            _discountWriteRepository = discountWriteRepository;
            _discountReadRepository = discountReadRepository;
        }

        public async Task<DeleteDiscountCommandResponse> Handle(DeleteDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            var discount = await _discountReadRepository.GetByIdAsync(request.Id);
            if (discount is null)
            {
                return new DeleteDiscountCommandResponse()
                {
                    Success = false,
                    Message = "Discount not found"
                };
            }

            var result = _discountWriteRepository.Remove(discount);

            return new DeleteDiscountCommandResponse
            {
                Message = "Discount deleted",
                Success = result

            };

        }
    }
}
