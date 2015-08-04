using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacContrib.NSubstitute;
using Brigita.Infrastructure.Pages;
using Brigita.Dom.Categories;
using Brigita.Dom.Products;
using Brigita.Dom.Services.Categories;
using Brigita.Dom.Services.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Ploeh.AutoFixture;
using TestStack.Dossier;
using NSubstitute;
using Brigita.Dom.Services.Test.Infrastructure;

namespace Brigita.Dom.Services.Test
{   
    [TestClass]
    public class ProductTests
    {                
        [TestMethod]
        public void ProductsByCategory() {
            using(var x = new AutoSubstitute()) 
            {
                var categories = Builder<ProductCategory>.CreateListOfSize(20).BuildList();
                var desiredCategory = Pick.Randomly.From(categories);

                var products = Builder<Product>.CreateListOfSize(200)
                                                    .All()
                                                        .Set(p => p.ProductCategories, () => new[] { Pick.Randomly.From(categories) })
                                                    .ListBuilder
                                                    .BuildList();

                x.Resolve<IRepository<Product>>().TableNoTracking
                                                        .Returns(new EnumerableQuery<Product>(products));

                x.Resolve<ICategories>().FindCatFamily(Arg.Is(desiredCategory.ID))
                                            .Returns(new[] { new Category() { ID = desiredCategory.ID } });
                
                var productService = x.Resolve<BrigitaProducts>();

                
                int pageSize = 20;

                var expectedProducts = products
                                        .Where(p => p.ProductCategories.Any(c => c.ID == desiredCategory.ID))
                                        .OrderBy(p => p.ID);

                int expectedPageCount = expectedProducts.Count() / pageSize + 1;
                
                
                var listPage = productService.GetProductsByCategory(desiredCategory.ID, new ListPageSpec(0, pageSize));

                Assert.AreEqual(expectedPageCount, listPage.PageCount);


                Func<int, int, IEnumerable<IProduct>> fnAggregatePages = null;

                fnAggregatePages = 
                    (i, c) => {
                        var page = productService.GetProductsByCategory(desiredCategory.ID, new ListPageSpec(i++, pageSize)).AsEnumerable();

                        if(i < c) {
                            page = page.Concat(fnAggregatePages(i, c));
                        }

                        return page;
                    };


                var aggregatedProducts = fnAggregatePages(0, expectedPageCount)
                                            .OrderBy(p => p.ID);

                Assert.IsTrue(expectedProducts.SequenceEqual(aggregatedProducts));

                //Try stupid pagespec: what happens? Nothing, hopefully
                Assert.AreEqual(0, productService.GetProductsByCategory(desiredCategory.ID, new ListPageSpec(100, 100)).Count());
            }
        }

    }
}
