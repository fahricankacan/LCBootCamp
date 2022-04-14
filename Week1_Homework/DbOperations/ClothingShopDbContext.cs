using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
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

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        
    }
}
