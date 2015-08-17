using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Infrastructure;
using AutoMapper;
using Nop.Core.Domain.Catalog;
using Brigita.Queries.Products;
using Brigita.Queries.Bits;
using System.Reflection;
using System.Linq.Expressions;
using AutoMapper.Mappers;
using Brigita.Dom.Bits;
using Brigita.Queries.Teasers;
using Brigita.Dom.Services.Media;


namespace Brigita.Queries
{
    
    public class AutoMapperInit : StartupTask
    {
        public override void Run() 
        {
            Mapper.CreateMap<decimal, CurrencyValue>()
                .ProjectUsing(d => new CurrencyValue() { Amount = d, Rate = 1M });

            Mapper.CreateMap<decimal?, CurrencyValue>()
                .ProjectUsing(d => d.HasValue 
                                    ? new CurrencyValue() { Amount = (decimal)d, Rate = 1M } 
                                    : null);


        }
    }
}
