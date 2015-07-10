using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure
{
    public interface IDependencyBinder
    {
        void Bind<T>(T instance);
        void Bind<T>(Func<IDependencyContainer, T> fnFactory);
        void Bind<T, TImp>() where TImp : T;

        void BindSingleton<T>(T instance);
        void BindSingleton<T>(Func<IDependencyContainer, T> fnFactory);
        void BindSingleton<T, TImp>() where TImp : T;

        void BindGeneric(Type intType, Type impType);

        void BindTransient<T, TImp>() where TImp : T;
        void BindTransient<T>(Func<IDependencyContainer, T> fnFactory);
    }
}
