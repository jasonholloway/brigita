using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;

namespace Brigita.Queries.Teasers
{
    public class TeaserPageQuery : IQuery
    {
        public int CategoryID { get; set; }
        public ListPageSpec<TeaserModel> PageSpec { get; set; }
    }
}
