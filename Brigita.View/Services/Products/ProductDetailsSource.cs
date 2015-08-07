using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Brigita.Dom.Services.Products;
using Brigita.View.Products;
using Nop.Core.Domain.Catalog;
using AutoMapper.QueryableExtensions;
using Nop.Core;
using Brigita.Dom.Services.Context;
using AutoMapper;

namespace Brigita.View.Services.Products
{
    public class ProductDetailsSource : IProductDetailsSource
    {
        IRepo<Product> _repo;
        IWorkContext _workCtx;
        ILocalizerSource<ProductDetails> _localizerSrc;

        public ProductDetailsSource(IRepo<Product> repo, IWorkContext workCtx, ILocalizerSource<ProductDetails> localizerSrc) {
            _repo = repo;
            _workCtx = workCtx;
            _localizerSrc = localizerSrc;
        }

        static ProductDetailsSource() {
            Mapper.CreateMap<Product, ProductDetails>();
        }


        public ProductDetails GetDetails(int productID) 
        {
            var product = _repo.Include(p => p.ProductPictures)
                                .First(p => p.ID == productID);
            
            var details = _repo.Where(p => p.ID == productID)
                                .Project().To<ProductDetails>()
                                .First();

            var localizer = _localizerSrc.GetLocalizerUsing<Product>(_workCtx.WorkingLanguage.ID);
            localizer.Localize(details);

            return details;
        }
    }
}
