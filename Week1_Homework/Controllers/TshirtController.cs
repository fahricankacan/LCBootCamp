using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Week1_Homework.Application.TshirtOperations.Commands.Create;
using Week1_Homework.Common;
using Week1_Homework.DbOperations;
using Week1_Homework.Entities;
using FluentValidation;
using Week1_Homework.Application.TshirtOperations.Commands.Update;
using System.ComponentModel.DataAnnotations;
using Week1_Homework.Application.TshirtOperations.Queries.GetAll;
using Week1_Homework.Application.TshirtOperations.Commands.Delete;
using Week1_Homework.Application.TshirtOperations.Queries.GetById;

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

            //var result = _clothingShopDbContext.Tshirts.ToList();
            TshirtGetAllQuery query = new TshirtGetAllQuery(_clothingShopDbContext, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TshirtGetByIdQuery query = new(_clothingShopDbContext, _mapper);
            TshirtGetByIdQueryValidator validator = new(id);
            validator.ValidateAndThrow(query);
            var result = query.Handle(id);
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

        [HttpPut]
        public IActionResult UpdateTshirt(int id,[FromBody]UpdateTshirtViewModel updateTshirtViewModel)
        {
            UpdateTshirtCommand command = new(_clothingShopDbContext);
            UpdateTshirtCommandValidator validator = new(id);
            validator.ValidateAndThrow(updateTshirtViewModel);
            command.Handle(id, updateTshirtViewModel);

            return Ok();
            
        }

        [HttpDelete]
        public IActionResult DeleteTshirt(int id)
        {
            DeleteTshirtCommand command = new(_clothingShopDbContext);
            DeleteTshirtCommandValidator validator = new(id);
            validator.ValidateAndThrow(command);
            command.Handle(id);
            return Ok();
        }
    }
}
