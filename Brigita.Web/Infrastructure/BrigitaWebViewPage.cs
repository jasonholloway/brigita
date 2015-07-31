using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Brigita.Web.Infrastructure
{
    class PageSpec
    {
        public string Title;
        public readonly LinkCollection CssFiles;
        public readonly LinkCollection ScriptFiles;

        public PageSpec(UrlHelper url) {
            CssFiles = new LinkCollection(url);
            ScriptFiles = new LinkCollection(url);
        }

    }


    public abstract class BrigitaWebViewPage<TModel> : WebViewPage<TModel>
    {
        public string Title {
            get { return _lzPageSpec.Value.Title; }
            set { _lzPageSpec.Value.Title = value; }
        }

        public LinkCollection CssFiles {
            get { return _lzPageSpec.Value.CssFiles; }
        }

        public LinkCollection ScriptFiles {
            get { return _lzPageSpec.Value.ScriptFiles; }
        }

        public string BaseUrl {
            get { return "http://localhost:22339"; }
        }
        


        Lazy<PageSpec> _lzPageSpec;

        public BrigitaWebViewPage() 
        {
            _lzPageSpec = new Lazy<PageSpec>(
                                () => {
                                    var spec = (PageSpec)Page.PageSpec;

                                    if(spec == null) {
                                        spec = new PageSpec(Url);
                                        Page.PageSpec = spec;
                                    }

                                    return spec;
                                });
        }
        
    }
}
