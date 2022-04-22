using Week2.Application.Repositories.ProductRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.ProductRepository
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(Week2DbContext context) : base(context)
        {
        }
    }
}
