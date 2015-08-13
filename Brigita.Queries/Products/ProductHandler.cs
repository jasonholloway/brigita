using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Data;
using Brigita.Dom.Services.Context;
using Brigita.Infrastructure.Trees;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using AutoMapper.QueryableExtensions;

namespace Brigita.Queries.Products
{
    public class ProductHandler : IQueryHandler<ProductQuery, ProductModel>
    {
        IRepo<Product> _repo;
        IWorkContext _workCtx;
        ILocalizerSource<ProductModel> _localizerSrc;

        public ProductHandler(
                    IRepo<Product> repo, 
                    IWorkContext workCtx, 
                    ILocalizerSource<ProductModel> localizerSrc) 
        {
            _repo = repo;
            _workCtx = workCtx;
            _localizerSrc = localizerSrc;
        }

        static ProductHandler() {
            Mapper.CreateMap<Product, ProductModel>();
        }
        

        public ProductModel Enquire(ProductQuery query)
        {
            var details = _repo.Include(p => p.ProductPictures)
                                .Where(p => p.ID == query.ProductID)
                                .Project().To<ProductModel>()
                                .First();

            var localizer = _localizerSrc.GetLocalizerUsing<Product>(_workCtx.WorkingLanguage.ID);
            localizer.Localize(details);

            return details;
        }
    }
}
