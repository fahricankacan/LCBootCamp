using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;
using Week2.Domain.Entities;
using Week2.Persistence.Contexts;

namespace Week2.Persistence.Repositories.InventoryRepository
{
    public class InventoryReadRepository : ReadRepository<Inventory> , IInventoryReadRepository
    {
        public InventoryReadRepository(Week2DbContext context) : base(context)
        {
        }
    }

}
