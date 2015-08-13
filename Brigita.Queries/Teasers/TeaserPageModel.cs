using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries.Bits;

namespace Brigita.Queries.Teasers
{
    public class TeaserPageModel : IProductContextProvider
    {
        public int CurrentCategoryID { get; set; }
        public string CurrentCategoryName { get; set; }
        public ListPageModel<TeaserModel> ListPage { get; set; }
    }
}
