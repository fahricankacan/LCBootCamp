using AutoMapper;
using Week1_Homework.Application.TshirtOperations.Commands.Create;
using Week1_Homework.Application.TshirtOperations.Commands.Update;
using Week1_Homework.Application.TshirtOperations.Queries.GetAll;
using Week1_Homework.Application.TshirtOperations.Queries.GetById;
using Week1_Homework.Application.TshirtOperations.Queries.Search;
using Week1_Homework.Entities;

namespace Week1_Homework.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTshirViewModel, Tshirt>();
            CreateMap<UpdateTshirtViewModel, Tshirt>();
            CreateMap<TshirtGetByIdQueryViewModel, Tshirt>();
            CreateMap<Tshirt, TshirtGetByIdQueryViewModel>();
            CreateMap<Tshirt, TshirtGetAllQueryViewModel>();
            CreateMap<TshirtGetAllQueryViewModel, Tshirt>();
            CreateMap<Tshirt, TshirtSearchViewModel>();
        }
    }
}
