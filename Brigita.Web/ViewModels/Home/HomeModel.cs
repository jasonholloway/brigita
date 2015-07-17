using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.ViewModels.Home
{
    public class HomeModel : IWebPageModel
    {
        public string Title { get; set; }
        public string HeadCustom { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string CanonicalURLs { get; set; }
        public string FaviconURL { get; set; }
        public bool DisplayProfiler { get; set; }

        public string Greeting { get; set; }
    }
    



}
