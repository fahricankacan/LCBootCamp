using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Week1_Homework.Application.TshirtOperations.Commands.Create;
using Week1_Homework.Common;
using Week1_Homework.DbOperations;
using Week1_Homework.Entities;
using FluentValidation;

namespace Week1_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TshirtController : ControllerBase
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;
        private readonly IMapper _mapper;

        public TshirtController(IClothingShopDbContext clothingShopDbContext, IMapper mapper)
        {
            _clothingShopDbContext = clothingShopDbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetThirts()
        {
            Tshirt tshirt = new Tshirt
            {
                Id = 1,
                Category = CategoriesEnum.Man,
                Color = ColorsEnum.red,
                Explanation = "erkek tshirt",
                Price = 29.99m,
                Title = "Yeni Sezon Erkek Tshirt"
            };

            //string a = tshirt.Category.ToString();

           var result = _clothingShopDbContext.Tshirts.ToList();
            
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateThirt(CreateTshirViewModel TshirtViewModel)
        {
            CreateTshirtCommand command = new CreateTshirtCommand(_clothingShopDbContext,_mapper);
            CreateTshirtCommandValidator validator = new();
            validator.ValidateAndThrow(TshirtViewModel);
            command.Handle(TshirtViewModel);
            return Ok();
        }
    }
}
