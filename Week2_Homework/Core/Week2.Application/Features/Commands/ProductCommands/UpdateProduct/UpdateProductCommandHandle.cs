using MediatR;
using Week2.Application.Repositories.ProductRepository;

namespace Week2.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandle : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCommandHandle(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
           
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Product not found"
                };
            }
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            product.InventoryId = request.InventoryId;
            product.DiscountId = request.DiscountId;
            
            await _productWriteRepository.SaveAsync();
            
            return new UpdateProductCommandResponse
            {
                Success = true,
                Message = "Product updated successfully"
            };
        }
    }


}
