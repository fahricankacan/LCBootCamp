using Week2.Application.Repositories.InventoryRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.InventoryRepository
{
    public class InventoryWriteRepository : WriteRepository<Inventory>, IInventoryWriteRepository
    {
        public InventoryWriteRepository(Week2DbContext context) : base(context)
        {
        }
    }




}
