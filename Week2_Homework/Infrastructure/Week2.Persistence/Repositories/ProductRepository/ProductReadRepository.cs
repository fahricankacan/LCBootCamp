using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.ProductRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.ProductRepository
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(Week2DbContext context) : base(context)
        {
        }
    }
}
