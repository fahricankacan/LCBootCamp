using Microsoft.EntityFrameworkCore;
using Week1_Homework.Entities;

namespace Week1_Homework.DbOperations
{
    public interface IClothingShopDbContext
    {
        DbSet<Tshirt> Tshirts { get; set; }
        int SaveChanges();
    }
}
