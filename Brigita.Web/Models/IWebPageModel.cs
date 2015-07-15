using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Domain.Models
{
    public interface IWebPageModel
    {
        string Title { get; }
        string HeadCustom { get; }
        string MetaDescription { get; }
        string MetaKeywords { get; }
        string CanonicalURLs { get; }
        string FaviconURL { get; }
        bool DisplayProfiler { get; }

        void Grind();
    }




    public class MixinDefAttribute : Attribute
    {
        public MixinDefAttribute(Type type) {
            //...
        }
    }



    [MixinDef(typeof(MixinImp))]
    public interface IMixinDef
    {
        string Title { get; }
        void Bark();
    }


    public class MixinImp : IMixinDef
    {

        string _t;

        public MixinImp(object mainObj) { //type of ctor arg constrains applicability!

	    }

        public string Title {
            get { throw new NotImplementedException(); }
        }

        public void Bark() {
            if(_t == blah) { }

            throw new NotImplementedException();
        }
    }



}
 