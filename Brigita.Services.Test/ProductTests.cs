using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Brigita.Core.Infrastructure.Pages;
using Brigita.Domain.Categories;
using Brigita.Domain.Products;
using Brigita.Services.Categories;
using Brigita.Services.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Ploeh.AutoFixture;

namespace Brigita.Services.Test
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductsByCategory() {
            using(var mock = AutoMock.GetLoose()) 
            {
                var fix = new Fixture();
                var products = fix.CreateMany<NopProduct>(100);
                
                mock.Mock<IRepository<NopProduct>>()
                        .SetupGet(r => r.TableNoTracking)
                        .Returns(() => new EnumerableQuery<NopProduct>(products));

                mock.Mock<ICategories>()
                        .Setup(c => c.FindCatFamily(5))
                        .Returns(new[] { fix.Create<Category>(new Category { ID = 5 }) });
                
                var service = mock.Create<BrigitaProducts>();

                var result = service.GetProductsByCategory(0, new ListPageSpec(0, 20));


                throw new NotImplementedException();
            }
        }



    }
}
