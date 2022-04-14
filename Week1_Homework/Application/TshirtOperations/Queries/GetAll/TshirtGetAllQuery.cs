using AutoMapper;
using Week1_Homework.DbOperations;
using System.Collections;
using System.Linq;
using Week1_Homework.Common;
using System.Collections.Generic;

namespace Week1_Homework.Application.TshirtOperations.Queries.GetAll
{
    public class TshirtGetAllQuery
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;
        private readonly IMapper _mapper;

        public TshirtGetAllQuery(IClothingShopDbContext clothingShopDbContext, IMapper mapper)
        {
            _clothingShopDbContext = clothingShopDbContext;
            _mapper = mapper;
        }

        
        public IEnumerable<TshirtGetAllQueryViewModel> Handle()
        {
            var allTshirts = _clothingShopDbContext.Tshirts;
            List<TshirtGetAllQueryViewModel> tshirtViewModelList = new List<TshirtGetAllQueryViewModel>();

            foreach (var tshirt in allTshirts)
            {
                tshirtViewModelList.Add(_mapper.Map<TshirtGetAllQueryViewModel>(tshirt));
            }

            return tshirtViewModelList;
        }

    }

    public class TshirtGetAllQueryViewModel
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
