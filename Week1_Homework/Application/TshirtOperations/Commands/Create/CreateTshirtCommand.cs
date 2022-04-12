using Week1_Homework.DbOperations;
using Week1_Homework.Entities;
using System.Linq;
using Week1_Homework.Common;
using System;
using AutoMapper;

namespace Week1_Homework.Application.TshirtOperations.Commands.Create
{
    public class CreateTshirtCommand
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;
        private readonly IMapper _mapper;

        public CreateTshirtCommand(IClothingShopDbContext clothingShopDbContext, IMapper mapper)
        {
            _clothingShopDbContext = clothingShopDbContext;
            _mapper = mapper;
        }

        public void Handle (CreateTshirViewModel tshirtViewModel)
        {
          
            if(Enum.IsDefined(typeof(ColorsEnum), tshirtViewModel.Color) is false)
            {
                throw new InvalidOperationException("Renk mevcut değil");
            }
            if (Enum.IsDefined(typeof(CategoriesEnum), tshirtViewModel.Category) is false)
            {
                throw new InvalidOperationException("Kategori mevcut değil");
            } 
            if (Enum.IsDefined(typeof(SizeEnum), tshirtViewModel.Size) is false)
            {
                throw new InvalidOperationException("Kategori mevcut değil");
            }

            Tshirt tshirt = new Tshirt();
            tshirt = _mapper.Map<Tshirt>(tshirtViewModel);

            _clothingShopDbContext.Tshirts.Add(tshirt);
            _clothingShopDbContext.SaveChanges();
        }

      
    }
    public class CreateTshirViewModel
    {
        public string Title { get; set; }
        public CategoriesEnum Category { get; set; }
        public ColorsEnum Color { get; set; }
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }
        public string Explanation { get; set; }

    }


}
