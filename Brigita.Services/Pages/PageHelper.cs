using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Services.Cache;

namespace Brigita.Services.Pages
{
    [CacheZone("PageHelper")]
    public class PageHelper : IPageHelper
    {
        public PageHelper() {
            //need to get current store info from somewhere...
        }

        [Cache("Title")]
        public string BuildPageTitle(string name) {
            return string.Format("Brigitas Bodite - {0}", name);
        }


    }
}
