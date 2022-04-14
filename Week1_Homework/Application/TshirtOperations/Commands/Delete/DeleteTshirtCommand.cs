using System.Linq;
using Week1_Homework.DbOperations;
using System;
using System.Threading.Tasks;

namespace Week1_Homework.Application.TshirtOperations.Commands.Delete
{
    public class DeleteTshirtCommand
    {
         private readonly IClothingShopDbContext _clothingShopDbContext;

        public DeleteTshirtCommand(IClothingShopDbContext clothingShopDbContext)
        {
            _clothingShopDbContext = clothingShopDbContext;
        }

        public async Task Handle(int id)
        {
            var tshirt = _clothingShopDbContext.Tshirts.SingleOrDefault(p => p.Id == id);

            if (tshirt is null)
            {
                throw new InvalidOperationException("Tshirt bulunamadı.");
            }

            _clothingShopDbContext.Tshirts.Remove(tshirt);

            await _clothingShopDbContext.SaveChangesAsync();
            
        }
    }
}
