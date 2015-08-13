using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom.Locale;

namespace Brigita.Dom.Services.Locale
{
    public class LocalizerSchema<TSubject>
    {
        Lazy<string> _lzEntityName;
        ConcurrentDictionary<string, Action<TSubject, string>> _dSetters;


        public LocalizerSchema() {
            _dSetters = new ConcurrentDictionary<string, Action<TSubject, string>>();
            _lzEntityName = new Lazy<string>(() => GetEntityName(typeof(TSubject)));
        }


        public string EntityName {
            get { return _lzEntityName.Value; }
        }

        public Action<TSubject, string> GetSetter(string propName) {
                return _dSetters.GetOrAdd(
                                    propName,
                                    k => BuildSetter(k)
                                    );
        }



        static string GetEntityName(Type entType) 
        {
            var att = entType
                        .GetCustomAttributes(typeof(LocalizeAsAttribute), false)
                        .Cast<LocalizeAsAttribute>()
                        .FirstOrDefault();

            return att != null
                    ? GetEntityName(att.AliasType)
                    : entType.Name;
        }


        static Action<TSubject, string> BuildSetter(string propName) 
        {
            var prop = typeof(TSubject).GetProperty(propName);

            if(prop == null) {
                return (a1, a2) => { };
            }

            var exEntity = Expression.Parameter(typeof(TSubject));
            var exValue = Expression.Parameter(typeof(string));

            var exLambda = Expression.Lambda<Action<TSubject, string>>(
                                        Expression.Call(
                                                    exEntity,
                                                    prop.SetMethod,
                                                    exValue),
                                        exEntity,
                                        exValue);

            return exLambda.Compile();
        }

    }
}
