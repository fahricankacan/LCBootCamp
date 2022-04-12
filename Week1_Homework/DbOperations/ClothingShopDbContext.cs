using Microsoft.EntityFrameworkCore;
using Week1_Homework.Entities;

namespace Week1_Homework.DbOperations
{
    public class ClothingShopDbContext : DbContext,IClothingShopDbContext
    {
        public ClothingShopDbContext(DbContextOptions<ClothingShopDbContext> options) : base(options)
        {

        }
        public DbSet<Tshirt> Tshirts { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();     
        }
    }
}
