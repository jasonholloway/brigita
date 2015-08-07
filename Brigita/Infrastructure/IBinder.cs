using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure
{
    public interface IBinder
    {
        void Bind(Type type, object instance);
        void Bind(Type type, Func<IResolver, object> fnFactory);
        void Bind(Type intType, Type implType);

        void Bind<T>(T instance);
        void Bind<T>(Func<IResolver, T> fnFactory);
        void Bind<T, TImp>() where TImp : T;

        void BindSingleton<T>(T instance);
        void BindSingleton<T>(Func<IResolver, T> fnFactory);
        void BindSingleton<T, TImp>() where TImp : T;

        void BindGeneric(Type intType, Type impType);
        void BindGenericSingleton(Type intType, Type impType);

        void BindTransient<T, TImp>() where TImp : T;
        void BindTransient<T>(Func<IResolver, T> fnFactory);
    }
}
