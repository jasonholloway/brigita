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


namespace Brigita.Queries
{
    
    public class AutoMapperInit : IStartupTask
    {
        public void Execute() 
        {            
            Mapper.CreateMap<decimal, PriceModel>()
                    .ConstructProjectionUsing(d => new PriceModel() { Amount = d });

            Mapper.CreateMap<Product, ProductModel>();
            
        }

        public int Order {
            get { return 0; }
        }
    }
}
