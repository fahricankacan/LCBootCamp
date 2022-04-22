using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Features.Queries.CategoryQueries.GetAllCategories;
using Week2.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using Week2.Application.Features.Queries.CategoryQueries.SearchQuery;
using Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts;
using Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount;
using Week2.Application.Features.Queries.DiscountQueries.SearchDiscountQueryHandler;
using Week2.Application.Features.Queries.InventoryQueries.GetAllInventories;
using Week2.Application.Features.Queries.InventoryQueries.GetByIdInventory;
using Week2.Application.Features.Queries.InventoryQueries.SearchInventory;
using Week2.Application.Features.Queries.ProductQueries.SearchProduct;
using Week2.Domain.Entities;

namespace Week2.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //CategoryMappings
            CreateMap<Category, GetAllCategoriesQueryResponse>()
            .ReverseMap();
            CreateMap<Category, GetAllCategoriesQueryResponse>();
            
            CreateMap<Category, SearchCategoryQueryResponse>();
            CreateMap<Category, SearchCategoryQueryResponse>().ReverseMap();

            CreateMap<Category, GetByIdCategoryQueryResponse>();
            //CreateMap<Category, GetByIdCategoryQueryRe>()




            //Discount 
            CreateMap<Discount, GetAllDiscountsQueryResponse>();
            CreateMap<Discount, GetByIdDiscountQueryResponse>();
            CreateMap<Discount, SearchDiscountQueryResponse>();
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest., opt => opt.MapFrom(src => src.DiscountPercent));
               
                //.ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                //.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate));

            //Inventory
            CreateMap<Inventory, GetAllInventoriesQueryResponse>();
            CreateMap<Inventory, GetByIdInventoryQueryResponse>();
            CreateMap<Inventory, SearchInventoryQueryResponse>();
            //.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));


            //product
            CreateMap<Product, SearchProductQueryResponse>();

        }
    }
}
