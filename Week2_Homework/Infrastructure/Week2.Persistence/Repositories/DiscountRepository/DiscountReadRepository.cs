using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.DiscountRepository
{
    public class DiscountReadRepository : ReadRepository<Discount>, IDiscountReadRepository
    {
        public DiscountReadRepository(Week2DbContext context) : base(context)
        {
        }
    }
}
