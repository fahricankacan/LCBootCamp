using MediatR;
using Week2.Application.Repositories.ProductRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var p =await _productReadRepository.GetSingleAsync(p => p.Name == request.Name);

            if(p is not null)
            {
                return new CreateProductCommandResponse()
                {
                    Success = false,
                    Message = "Product already exists"
                };
            }
            
            var id = Guid.NewGuid();
            Product product = new Product
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                InventoryId = request.InventoryId,
                DiscountId = request.DiscountId
            };

            var result = await _productWriteRepository.AddAsync(product);

            return new CreateProductCommandResponse { Success = result, Message = result ? "Product created successfully" : "Product creation failed" };
        }
    }
}
