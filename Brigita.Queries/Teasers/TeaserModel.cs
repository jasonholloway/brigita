using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Dom;
using Brigita.Dom.Bits;
using Brigita.Dom.Services.Media;
using Brigita.Queries.Bits;
using Nop.Core.Domain.Catalog;

namespace Brigita.Queries.Teasers
{
    public class TeaserModel : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CurrencyValue Price { get; set; }
        public Pic Picture { get; set; }
        public Link Link { get; set; }




        public class MapConfig : StartupTask
        {
            public override void Run() 
            {
                Mapper.CreateMap<Product, TeaserModel>()
                        .ForMember(t => t.Picture, x => x.MapFrom(p => p.ProductPictures.Any()
                                                                        ? new Pic() { Id = p.ProductPictures.Select(pp => pp.PictureId).FirstOrDefault() }
                                                                        : null));
            
            }
        }
        
    }
}
