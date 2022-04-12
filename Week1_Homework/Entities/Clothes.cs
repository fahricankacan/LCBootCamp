using Week1_Homework.Common;

namespace Week1_Homework.Entities
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoriesEnum Category { get; set; }
        public decimal Price { get; set; }
        public ColorsEnum Color { get; set; }
        public string Explanation { get; set; }
    }
}
