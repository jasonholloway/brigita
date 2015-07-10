using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brigita.Web.Infrastructure;

namespace Brigita.Web.Models
{
    public class PageModel
    {

        public PageModelProperties Page { get; private set; }


        public PageModel()
        {
            this.Page = new PageModelProperties();
        }


        public class PageModelProperties
        {
            public PageModelProperties()
            {
                this.CssLinks = new CssLinkCollection();
                this.FooterCssLinks = new CssLinkCollection();
                this.ScriptLinks = new ScriptLinkCollection();
                this.FooterScriptLinks = new ScriptLinkCollection();
            }

            public IHtmlString Title { get; set; }
            public IHtmlString HeadCustom { get; set; }
            public IHtmlString MetaDescription { get; set; }
            public IHtmlString MetaKeywords { get; set; }
            public IHtmlString CanonicalURLs { get; set; }
            public IHtmlString FaviconUrl { get; set; }

            public CssLinkCollection CssLinks { get; set; }
            public CssLinkCollection FooterCssLinks { get; set; }
            public ScriptLinkCollection ScriptLinks { get; set; }
            public ScriptLinkCollection FooterScriptLinks { get; set; }

            public bool DisplayProfiler { get; set; } 
        }
    }
}