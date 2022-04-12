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
                        Category = Common.Categories.Çocuk,
                        Color = Common.Colors.red,
                        Title = "Kımrızı çocuk tshirt",
                        Price = 19.99m,
                        Explanation = "Yeni sezon kırmızı çocuk tshirt.",
                        Size = Common.ChildSizeEnum.fiveToSix.ToString(),
                        

                    },
                    new Entities.Tshirt
                    {
                        Id = 2,
                        Category = Common.Categories.Çocuk,
                        Color = Common.Colors.blue,
                        Title = "Bisiklet Yaka Baskılı Kısa Kollu Erkek Çocuk Tişört",
                        Price = 39.99m,
                        Explanation = "Yeni sezon  çocuk tshirt.",
                        Size = Common.ChildSizeEnum.EightToNine.ToString(),

                    },
                    new Entities.Tshirt
                    {
                        Id = 3,
                        Category = Common.Categories.Erkek,
                        Color = Common.Colors.green,
                        Title = "LCW BASIC Bisiklet Yaka Kısa Kollu Penye Erkek Tişört",
                        Price = 59.99m,
                        Explanation = "Pamuklu penye kumaştan kısa kollu tişört.",
                        Size = Common.SizeEnum.M.ToString(),


                    },
                    new Entities.Tshirt

                    {
                        Id = 4,
                        Category = Common.Categories.Kadın,
                        Color = Common.Colors.white,
                        Title = "LCW BASIC V Yaka Düz Kısa Kollu Kadın Pamuklu Tişört",
                        Price = 49.99m,
                        Explanation = "%100 pamuklu kumaştan.",
                        Size = Common.SizeEnum.S.ToString(),



                    },
                     new Entities.Tshirt
                     {
                         Id = 5,
                         Category = Common.Categories.Kadın,
                         Color = Common.Colors.black,
                         Title = "LCW BASIC V Yaka Düz Kısa Kollu Kadın Pamuklu Tişört",
                         Price = 49.99m,
                         Explanation = "%100 pamuklu kumaştan.",
                         Size = Common.SizeEnum.L.ToString(),
                     }
                    );

                context.SaveChanges();
            }
        }
    }
}
