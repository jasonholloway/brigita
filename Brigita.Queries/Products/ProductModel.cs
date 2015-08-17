using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Dom;
using Brigita.Dom.Bits;
using Brigita.Dom.Locale;
using Brigita.Dom.Services.Media;
using Brigita.Queries.Bits;
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
        public Piccy Picture { get; set; }

        public CurrencyValue Price { get; set; }
        public CurrencyValue OldPrice { get; set; }
        public CurrencyValue SpecialPrice { get; set; }
        public CurrencyValue AdditionalShippingCharge { get; set; }
    }
}
