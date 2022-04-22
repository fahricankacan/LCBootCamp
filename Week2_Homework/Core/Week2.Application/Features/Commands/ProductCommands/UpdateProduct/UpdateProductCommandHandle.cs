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

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }


            if (await CheckNameIsExist(request.Name))
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Product name is exist"
                };
            }


            product.Name = request.Name ?? product.Name;
            product.Description = request.Description ?? product.Description;
            product.Price = request.Price ?? product.Price;
            product.CategoryId = request.CategoryId ?? product.CategoryId;
            product.InventoryId = request.InventoryId ?? product.InventoryId;
            product.DiscountId = request.DiscountId ?? product.DiscountId;

            _productWriteRepository.Update(product);

            await _productWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Success = true,
                Message = "Product updated successfully"
            };
        }

        private async Task<bool> CheckNameIsExist(string? name)
        {
            if (name is null)
            {
                return false;
            }

            var productName = await _productReadRepository.GetSingleAsync(p => p.Name == name);
            if (productName == null)
            {
                return false;
            }

            return true;
        }

        private bool CheckRequestIsEmpty(UpdateProductCommandRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) 
                && string.IsNullOrEmpty(request.Description)
                && request.Price == null &&
                request.CategoryId == null && 
                request.InventoryId == null&& 
                request.DiscountId == null)
            {
                return true;
            }

            return false;
        }
    }


}
