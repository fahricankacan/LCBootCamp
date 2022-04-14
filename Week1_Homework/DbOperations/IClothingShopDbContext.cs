using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Week1_Homework.Entities;

namespace Week1_Homework.DbOperations
{
    public interface IClothingShopDbContext
    {
        DbSet<Tshirt> Tshirts { get; set; }
        int SaveChanges();
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default);

    }
}
