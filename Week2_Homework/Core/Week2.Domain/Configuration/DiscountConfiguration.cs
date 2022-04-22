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
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.DiscountPercent).IsRequired();
            
            


            entity.HasMany(e => e.Products)
                .WithOne(e => e.Discount)
                .HasForeignKey(e => e.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
