using MediatR;
using Week2.Application.Repositories.ProductRepository;

namespace Week2.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandle : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public DeleteProductCommandHandle(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetSingleAsync(p => p.Id == request.Id);

            if (product is null)
            {
                return new DeleteProductCommandResponse
                {
                    Message = "Product is null.",
                    Succes = false
                };
            }

            var result = _productWriteRepository.Remove(product);
            await _productWriteRepository.SaveAsync();

            return new DeleteProductCommandResponse
            {
                Message = "Product deleted.",
                Succes = result
            };

        }
    }
}



