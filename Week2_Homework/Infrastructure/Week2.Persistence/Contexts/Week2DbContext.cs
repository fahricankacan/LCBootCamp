using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Domain.Common;
using Week2.Domain.Entities;

namespace Week2.Persistence.Contexts
{
    public class Week2DbContext : DbContext
    {
        public Week2DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //intercepter example
            //https://stackoverflow.com/questions/62151/datetime-now-vs-datetime-utcnow
            //DateTime.UtcNow faster than DateTime.Now
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.DeleteDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
