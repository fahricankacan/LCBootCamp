using Week1_Homework.DbOperations;
using Week1_Homework.Entities;

namespace Week1_Homework.Application.TshirtOperations.Commands.Create
{
    public class CreateTshirtCommand
    {
        private readonly IClothingShopDbContext _clothingShopDbContext;

        public CreateTshirtCommand(IClothingShopDbContext clothingShopDbContext)
        {
            _clothingShopDbContext = clothingShopDbContext;
        }

        public void Command (Tshirt tshirt)
        {
            //CreateTShirtViewModel createTShirtViewModel = new CreateTShirtViewModel
            //{
            //    Category = tshirt.Category.ToString(),
            //    Color = tshirt.Color.ToString(),
            //    Explanation = tshirt.Explanation,
            //    Id = tshirt.Id,
            //    Price = tshirt.Price,
            //    Size = tshirt.Size,
            //    Title = tshirt.Title,
            //};

            _clothingShopDbContext.Tshirts.Add(tshirt);
            _clothingShopDbContext.SaveChanges();
        }
    }

    public class CreateTShirtViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Explanation { get; set; }

    }
}
