using AutoMapper;
using Week1_Homework.Application.TshirtOperations.Commands.Create;
using Week1_Homework.Entities;

namespace Week1_Homework.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTshirViewModel, Tshirt>();
        }
    }
}
