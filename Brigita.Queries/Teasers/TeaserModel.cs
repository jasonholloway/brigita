using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom.Bits;
using Brigita.Dom.Services.Media;
using Brigita.Queries.Bits;

namespace Brigita.Queries.Teasers
{
    public class TeaserModel
    {
        public string Name { get; set; }
        public CurrencyValue Price { get; set; }
        public Piccy Image { get; set; }
        public Link Link { get; set; }
    }
}
