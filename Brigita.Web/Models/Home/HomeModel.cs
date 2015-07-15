using Brigita.Web.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Models.Home
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
    }


    [DtoCompose]
    public partial class HomeMod : IWebPageModel
    {

    }


}
