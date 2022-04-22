using Week2.Application.Repositories.DiscountRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.DiscountRepository
{
    public class DiscountWriteRepository : WriteRepository<Discount>, IDiscountWriteRepository
    {
        public DiscountWriteRepository(Week2DbContext context) : base(context)
        {
        }
    }
}
