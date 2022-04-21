using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Domain.Common;

namespace Week2.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        

        public ICollection<Product> Products { get; set; }
        
    }
}
