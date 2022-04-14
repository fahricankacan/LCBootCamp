using System.Linq;
using Week1_Homework.DbOperations;
using System;
using Week1_Homework.Common;
using AutoMapper;

namespace Week1_Homework.Application.TshirtOperations.Queries.GetById
{
    public class TshirtGetByIdQuery
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;
        private readonly IMapper _mapper;

        public TshirtGetByIdQuery(IClothingShopDbContext clothingShopDbContext, IMapper mapper)
        {
            _clothingShopDbContext = clothingShopDbContext;
            _mapper = mapper;
        }

        public TshirtGetByIdQueryViewModel Handle(int id)
        {
            var tshirt = _clothingShopDbContext.Tshirts.SingleOrDefault(p=>p.Id==id);

            if(tshirt == null)
            {
                throw new InvalidOperationException("Tshirt bulunamadı.");
            }

            //TshirtViewModel tshirtViewModel = new TshirtViewModel();
            return _mapper.Map<TshirtGetByIdQueryViewModel>(tshirt);
            
        }

      
    }
    public class TshirtGetByIdQueryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoriesEnum Category { get; set; }
        public ColorsEnum Color { get; set; }
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }
        public string Explanation { get; set; }
    }
}
