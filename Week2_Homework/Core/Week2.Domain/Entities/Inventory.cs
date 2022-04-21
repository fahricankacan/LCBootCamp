using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Domain.Common;

namespace Week2.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int Quantity { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
