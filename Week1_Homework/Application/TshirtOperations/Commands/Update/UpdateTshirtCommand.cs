using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Week1_Homework.Common;
using Week1_Homework.DbOperations;

namespace Week1_Homework.Application.TshirtOperations.Commands.Update
{
    public class UpdateTshirtCommand
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;
       

        public UpdateTshirtCommand(IClothingShopDbContext clothingShopDbContext)
        {
            _clothingShopDbContext = clothingShopDbContext;
            
        }

        public async Task Handle(int tshirtId,UpdateTshirtViewModel updateTshirtViewModel)
        {
            var tshirt =await _clothingShopDbContext.Tshirts.SingleOrDefaultAsync(t=>t.Id==tshirtId);

            if(tshirt is null)
            {
                throw new InvalidOperationException("Tshirt bulunamadı");
            }
            if (Enum.IsDefined(typeof(ColorsEnum), updateTshirtViewModel.Color) is false)
            {
                throw new InvalidOperationException("Renk mevcut değil");
            }
            if (Enum.IsDefined(typeof(CategoriesEnum), updateTshirtViewModel.Category) is false)
            {
                throw new InvalidOperationException("Kategori mevcut değil");
            }
            if (Enum.IsDefined(typeof(SizeEnum), updateTshirtViewModel.Size) is false)
            {
                throw new InvalidOperationException("Beden mevcut değil");
            }

            tshirt.Size = (updateTshirtViewModel.Size==default)?tshirt.Size:updateTshirtViewModel.Size;
            tshirt.Price = (updateTshirtViewModel.Price==default)?tshirt.Price:updateTshirtViewModel.Price;
            tshirt.Title= (updateTshirtViewModel.Title==default)?tshirt.Title:updateTshirtViewModel.Title;
            tshirt.Color= (updateTshirtViewModel.Color==default)?tshirt.Color:updateTshirtViewModel.Color;
            tshirt.Explanation= (updateTshirtViewModel.Explanation==default)?tshirt.Explanation:updateTshirtViewModel.Explanation;

            _clothingShopDbContext.Tshirts.Update(tshirt);
           
            await _clothingShopDbContext.SaveChangesAsync();
                                        
        }

    }
    public class UpdateTshirtViewModel
    {
        public string Title { get; set; }
        public CategoriesEnum Category { get; set; }       
        public ColorsEnum Color { get; set; }     
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }
        public string Explanation { get; set; }

    }
}
