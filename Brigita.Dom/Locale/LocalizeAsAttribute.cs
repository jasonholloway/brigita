using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Locale
{
    public class LocalizeAsAttribute : Attribute
    {
        public LocalizeAsAttribute(Type aliasType) {
            AliasType = aliasType;
        }

        public Type AliasType { get; private set; }
    }
}
