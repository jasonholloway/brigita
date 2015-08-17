using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Data;
using Brigita.Dom.Services.Localization;
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
            
//          I was imagining more of an apocalyptic heart-of-darkness kind-of-thing, where, having
//          been expelled from his language school, he would flee to the wilderness, contract malaria,
//          through force of deranged personality assume his own jungle fiefdom, grow fat, and more deranged,
//          and eventually die in an explosion. But yes, there are many dangers that could befall a young man abroad,
//          and he should be careful.
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
