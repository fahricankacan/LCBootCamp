using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Week1_Homework.Common;
using Week1_Homework.DbOperations;
using Week1_Homework.Entities;

namespace Week1_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TshirtController : ControllerBase
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;

        public TshirtController(IClothingShopDbContext clothingShopDbContext)
        {
            _clothingShopDbContext = clothingShopDbContext;
        }
        [HttpGet]
        public IActionResult GetThirts()
        {
            Tshirt tshirt = new Tshirt
            {
                Id = 1,
                Category = Categories.Erkek,
                Color = Colors.red,
                Explanation = "erkek tshirt",
                Price = 29.99m,
                Title = "Yeni Sezon Erkek Tshirt"
            };

            string a = tshirt.Category.ToString();

           var result = _clothingShopDbContext.Tshirts.ToList();
            

            return Ok(result);
        }
    }
}
