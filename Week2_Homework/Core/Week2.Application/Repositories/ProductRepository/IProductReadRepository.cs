using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Domain.Entities;

namespace Week2.Application.Repositories.ProductRepository
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
