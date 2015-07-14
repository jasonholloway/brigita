using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brigita.Web.Infrastructure;
using Brigita.Web.Domain.Models;

namespace Brigita.Web.Models
{

    public class PageModel : IPageModel
    {
        public IPageInfo Page { get; private set; }

        public PageModel()
        {
            this.Page = new _PageInfo();
        }


        class _PageInfo : IPageInfo
        {
            public string Title { get; set; }
            public string HeadCustom { get; set; }
            public string MetaDescription { get; set; }
            public string MetaKeywords { get; set; }
            public string CanonicalURLs { get; set; }
            public string FaviconUrl { get; set; }
            public bool DisplayProfiler { get; set; }
        }

    }



}