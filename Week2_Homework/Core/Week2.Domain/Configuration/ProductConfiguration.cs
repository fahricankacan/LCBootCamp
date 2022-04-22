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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Price).IsRequired();
            

            #region reletionship

            entity.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);
            entity.HasOne(e => e.Inventory)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.InventoryId);
            entity.HasOne(e => e.Discount)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.DiscountId);

            #endregion

        }
    }
}
