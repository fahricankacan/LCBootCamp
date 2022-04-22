using MediatR;
using Week2.Application.Repositories.ProductRepository;

namespace Week2.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandle : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public DeleteProductCommandHandle(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new DeleteProductCommandResponse
                {
                    Message = "Product is null.",
                    Succes = false
                };
            }

             _productWriteRepository.Remove(product);
            
            var result = await _productWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteProductCommandResponse
            {
                Message = result == true ? "Product deleted" : "Product not deleted",
                Succes = result
            };

        }
    }
}



