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
using System.Threading.Tasks;
using System.Collections;
using Week1_Homework.Application.TshirtOperations.Queries.Search;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace Week1_Homework.Controllers
{
    
    [Route("api/v1/[controller]")]
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
        public async Task<ActionResult> GetThirts()
        {
           
            TshirtGetAllQuery query = new TshirtGetAllQuery(_clothingShopDbContext, _mapper);
            var result =await query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTshirtById(int id)
        {
            TshirtGetByIdQuery query = new(_clothingShopDbContext, _mapper);
            TshirtGetByIdQueryValidator validator = new(id);
            validator.ValidateAndThrow(query);
            var result =await query.Handle(id);
            return Ok(result); 
        }

        [HttpPost]
        public async Task<ActionResult> CreateThirt(CreateTshirViewModel TshirtViewModel)
        {
            CreateTshirtCommand command = new CreateTshirtCommand(_clothingShopDbContext,_mapper);
            CreateTshirtCommandValidator validator = new();
            validator.ValidateAndThrow(TshirtViewModel);
            await command.Handle(TshirtViewModel);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTshirt(int id,[FromBody]UpdateTshirtViewModel updateTshirtViewModel)
        {
            UpdateTshirtCommand command = new(_clothingShopDbContext);
            UpdateTshirtCommandValidator validator = new(id);
            validator.ValidateAndThrow(updateTshirtViewModel);
            await command.Handle(id, updateTshirtViewModel);

            return Ok();          
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTshirt(int id)
        {
            DeleteTshirtCommand command = new(_clothingShopDbContext);
            DeleteTshirtCommandValidator validator = new(id);
            validator.ValidateAndThrow(command);
            await command.Handle(id);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TshirtSearchViewModel>>> GetSearchedTshirt([FromQuery] TshirtSearchViewModel tshirtSearch )
        {
            TshirtSearchQuery query = new TshirtSearchQuery(_clothingShopDbContext, _mapper);
            TshirtSearchQueryValidator validator = new();
            validator.ValidateAndThrow(tshirtSearch);
            var result = await query.Handle(tshirtSearch);
            return Ok(result);
        }
    }
}
