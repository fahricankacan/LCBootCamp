using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Features.Queries.CategoryQueries.GetAllCategories;
using Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts;
using Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount;
using Week2.Application.Features.Queries.InventoryQueries.GetAllInventories;
using Week2.Application.Features.Queries.InventoryQueries.GetByIdInventory;
using Week2.Domain.Entities;

namespace Week2.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, GetAllCategoriesQuery>()
            .ReverseMap();

            CreateMap<Discount, GetAllDiscountsQueryResponse>();
            CreateMap<Discount, GetByIdDiscountQueryResponse>();

            CreateMap<Inventory, GetAllInventoriesQueryResponse>();
            CreateMap<Inventory, GetByIdInventoryQueryResponse>();
            //.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        }
    }
}
