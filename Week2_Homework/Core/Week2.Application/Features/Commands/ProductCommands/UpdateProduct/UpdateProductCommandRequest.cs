using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InventoryId { get; set; }
        public Guid DiscountId { get; set; }
    }


}
