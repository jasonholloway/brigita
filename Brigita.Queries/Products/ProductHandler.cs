using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Data;
using Brigita.Dom.Services.Locale;
using Brigita.Infrastructure.Trees;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using AutoMapper.QueryableExtensions;

namespace Brigita.Queries.Products
{
    public class ProductHandler : IQueryHandler<ProductQuery, ProductModel>
    {
        IRepo<Product> _repo;
        ILocalizer<ProductModel> _localizer;

        public ProductHandler(
                    IRepo<Product> repo, 
                    ILocalizer<ProductModel> localizer) 
        {
            _repo = repo;
            _localizer = localizer;
        }

        static ProductHandler() {
            Mapper.CreateMap<Product, ProductModel>();
        }
        

        public ProductModel Enquire(ProductQuery query)
        {
            var model = _repo.Include(p => p.ProductPictures)
                                .Where(p => p.ID == query.ProductID)
                                .Project().To<ProductModel>()
                                .First();

            _localizer.Localize(model);

            return model;
        }
    }
}
