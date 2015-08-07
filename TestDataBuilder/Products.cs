using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using Nop.Data;

namespace TestDataBuilder
{
    static class Products
    {
        public static void Build() 
        {
            var ctx = new NopObjectContext("Data Source=JASON-THINK;Initial Catalog=Brigita;Integrated Security=True;Persist Security Info=False");
            var products = ctx.Set<Product>();
            
            var cats = ctx.Set<NopCategory>().ToArray();
            var pic = ctx.Set<Picture>().OrderByDescending(p => p.ID).First();

            foreach(var cat in cats) {
                for(int i = 0; i < 100; i++) {

                    var p = new Product() {
                        Name = "Product" + i,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow,
                        ShortDescription = "Short desc blah blah blah blah blah.",
                        FullDescription = "Full desc blah blah blah blah blah blah blah blah blah blah blah blah blah..."
                        //...
                    };

                    p.ProductCategories.Add(new ProductCategory() { 
                                                        Category = cat
                                                    });

                    p.ProductPictures.Add(new ProductPicture() { 
                                                        Picture = pic
                                                    });


                    products.Add(p);
                }
            }

            try {
                ctx.SaveChanges();
            }
            catch(Exception ex) {
                //...
            }
        }
    }
}
