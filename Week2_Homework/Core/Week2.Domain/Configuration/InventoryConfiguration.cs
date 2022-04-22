using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Domain.Entities;

namespace Week2.Domain.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Quantity).IsRequired();



            entity.HasMany(e=>e.Products)
                .WithOne(entity => entity.Inventory)
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
