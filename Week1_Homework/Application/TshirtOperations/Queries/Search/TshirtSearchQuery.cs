using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week1_Homework.Common;
using Week1_Homework.DbOperations;
using Week1_Homework.Entities;

namespace Week1_Homework.Application.TshirtOperations.Queries.Search
{
    public class TshirtSearchQuery
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;
        private readonly IMapper _mapper;

        public TshirtSearchQuery(IClothingShopDbContext clothingShopDbContext, IMapper mapper)
        {

            _clothingShopDbContext = clothingShopDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TshirtSearchViewModel>> Handle(TshirtSearchViewModel tshirtSearch)
        {
            IQueryable<Tshirt> query = _clothingShopDbContext.Tshirts;

            if (!string.IsNullOrEmpty(tshirtSearch.Title))
            {
                query = query.Where(p => p.Title.Contains(tshirtSearch.Title));
            }
            if (!string.IsNullOrEmpty(tshirtSearch.Explanation))
            {
                query = query.Where(p => p.Explanation.Contains(tshirtSearch.Explanation));
            }
            if (tshirtSearch.Color != null)
            {
                query = query.Where(p => p.Color == tshirtSearch.Color);

            }
            if (tshirtSearch.Size != null)
            {
                query = query.Where(p => p.Size == tshirtSearch.Size);

            }
            if (tshirtSearch.Category != null)
            {
                query = query.Where(p => p.Category == tshirtSearch.Category);

            }

            var searchedList = query.ToListAsync();
            List<TshirtSearchViewModel> mappedList = new List<TshirtSearchViewModel>();

            foreach (var tshirt in searchedList.Result)
            {
                mappedList.Add(_mapper.Map<TshirtSearchViewModel>(tshirt));
            }

            return await Task.FromResult(mappedList);

        }

    }

    public class TshirtSearchViewModel
    {
        public string Title { get; set; }
        public CategoriesEnum? Category { get; set; } = null;
        public decimal Price { get; set; }
        public ColorsEnum? Color { get; set; } = null;
        public string Explanation { get; set; }
        public SizeEnum? Size { get; set; } = null;
    }
}
