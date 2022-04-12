using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Week1_Homework.DbOperations
{
    public class DataGenerator
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new ClothingShopDbContext(serviceProvider.GetRequiredService<DbContextOptions<ClothingShopDbContext>>()))
            {
                if (context.Tshirts.Any())
                {
                    return;
                }
                context.Tshirts.AddRange(
                    new Entities.Tshirt
                    {
                        Id = 1,
                        Category = Common.CategoriesEnum.Child,
                        Color = Common.ColorsEnum.red,
                        Title = "Kımrızı çocuk tshirt",
                        Price = 19.99m,
                        Explanation = "Yeni sezon kırmızı çocuk tshirt.",
                        Size = Common.SizeEnum.S,
                        

                    },
                    new Entities.Tshirt
                    {
                        Id = 2,
                        Category = Common.CategoriesEnum.Child,
                        Color = Common.ColorsEnum.blue,
                        Title = "Bisiklet Yaka Baskılı Kısa Kollu Erkek Çocuk Tişört",
                        Price = 39.99m,
                        Explanation = "Yeni sezon  çocuk tshirt.",
                        Size = Common.SizeEnum.S,

                    },
                    new Entities.Tshirt
                    {
                        Id = 3,
                        Category = Common.CategoriesEnum.Man,
                        Color = Common.ColorsEnum.green,
                        Title = "LCW BASIC Bisiklet Yaka Kısa Kollu Penye Erkek Tişört",
                        Price = 59.99m,
                        Explanation = "Pamuklu penye kumaştan kısa kollu tişört.",
                        Size = Common.SizeEnum.M,


                    },
                    new Entities.Tshirt

                    {
                        Id = 4,
                        Category = Common.CategoriesEnum.Woman,
                        Color = Common.ColorsEnum.white,
                        Title = "LCW BASIC V Yaka Düz Kısa Kollu Kadın Pamuklu Tişört",
                        Price = 49.99m,
                        Explanation = "%100 pamuklu kumaştan.",
                        Size = Common.SizeEnum.S,



                    },
                     new Entities.Tshirt
                     {
                         Id = 5,
                         Category = Common.CategoriesEnum.Woman,
                         Color = Common.ColorsEnum.black,
                         Title = "LCW BASIC V Yaka Düz Kısa Kollu Kadın Pamuklu Tişört",
                         Price = 49.99m,
                         Explanation = "%100 pamuklu kumaştan.",
                         Size = Common.SizeEnum.L,
                     }
                    );

                context.SaveChanges();
            }
        }
    }
}
