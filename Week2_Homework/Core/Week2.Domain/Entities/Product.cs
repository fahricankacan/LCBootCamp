using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Domain.Common;

namespace Week2.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public int SKU { get; set; } barcode
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InventoryId { get; set; }
        public Guid DiscountId { get; set; }


        public Category Category { get; set; }
        public Inventory Inventory { get; set; }
        public Discount Discount{ get; set; }

    }
}
