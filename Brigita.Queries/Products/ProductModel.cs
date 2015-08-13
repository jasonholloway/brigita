using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Dom;
using Brigita.Dom.Locale;
using Brigita.Dom.Services.Media;
using Nop.Core.Domain.Catalog;

namespace Brigita.Queries.Products
{
    [LocalizeAs(typeof(Product))]
    public class ProductModel : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Sku { get; set; }
        public int TaxCategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public decimal AdditionalShippingCharge { get; set; }
        public Piccy Picture { get; set; }
    }
}
