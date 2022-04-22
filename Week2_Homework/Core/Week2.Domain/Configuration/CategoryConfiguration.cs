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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

            entity.HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
//https://www.gencayyildiz.com/blog/nedir-bu-onion-architecture-tam-teferruatli-inceleyelim/
//https://www.gencayyildiz.com/blog/onion-architectureda-cqrs-mediatr-pattern-automapper-fluent-validation/
//https://www.gencayyildiz.com/blog/cqrs-pattern-nedir-mediatr-kutuphanesi-ile-nasil-uygulanir/