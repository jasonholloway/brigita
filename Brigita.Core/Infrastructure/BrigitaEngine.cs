using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Brigita.Core.Infrastructure
{
    public class BrigitaEngine : IEngine
    {
        NopConfig _config;
        ITypeFinder _typeFinder;


        public ContainerManager ContainerManager { get; private set; }

        public BrigitaEngine() {
            _config = ConfigurationManager.GetSection("NopConfig") as NopConfig;
            _typeFinder = new WebAppTypeFinder(_config);
        }


        public void Build(Action<IDependencyBinder> fnReg) {
            var b = new ContainerBuilder();

            b.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            b.RegisterInstance(_config).As<NopConfig>().SingleInstance();
            b.RegisterInstance(this).As<IEngine>().SingleInstance();
            b.RegisterInstance(_typeFinder).As<ITypeFinder>().SingleInstance();

            fnReg(new ContainerRegistrarAdaptor(b));

            var container = b.Build();

            ContainerManager = new ContainerManager(container);

            DependencyResolver.SetResolver(
                                    new AutofacDependencyResolver(ContainerManager.Container)
                                    );
        }




        class ContainerAdaptor : IDependencyContainer
        {
            IContainer _container;

            public ContainerAdaptor(IContainer container) {
                _container = container;
            }

            public T Resolve<T>() {
                return _container.Resolve<T>();
            }
        }


        class ContainerRegistrarAdaptor : IDependencyBinder
        {
            ContainerBuilder _builder;

            public ContainerRegistrarAdaptor(ContainerBuilder builder) {
                _builder = builder;
            }

            public void Bind<T, TImp>() where TImp : T {
                _builder.RegisterType<TImp>()
                            .As<T>()
                            .InstancePerLifetimeScope();
            }

            public void Bind<T>(T instance) {
                _builder.Register<T>(_ => instance)
                            .InstancePerLifetimeScope();
            }

            public void Bind<T>(Func<IDependencyContainer, T> fnFactory) {
                _builder.Register<T>(c => fnFactory(new ContCtxAdaptor(c)))
                            .InstancePerLifetimeScope();
            }

            public void BindSingleton<T>(T instance) {
                _builder.Register<T>(_ => instance)
                            .SingleInstance();
            }

            public void BindSingleton<T>(Func<IDependencyContainer, T> fnFactory) {
                _builder.Register<T>(c => fnFactory(new ContCtxAdaptor(c)))
                            .SingleInstance();
            }

            public void BindSingleton<T, TImp>() where TImp : T {
                _builder.RegisterType<TImp>()
                            .As<T>()
                            .SingleInstance();
            }

            public void BindGeneric(Type intType, Type impType) {
                _builder.RegisterGeneric(impType)
                                .As(intType)
                                .InstancePerLifetimeScope();
            }

            public void BindTransient<T, TImp>() where TImp : T {
                _builder.RegisterType<TImp>()
                                .As<T>()
                                .InstancePerDependency();
            }

            public void BindTransient<T>(Func<IDependencyContainer, T> fnFactory) {
                _builder.Register<T>(c => fnFactory(new ContCtxAdaptor(c)))
                            .InstancePerDependency();
            }


            class ContCtxAdaptor : IDependencyContainer
            {
                IComponentContext _context;

                public ContCtxAdaptor(IComponentContext context) {
                    _context = context;
                }

                public T Resolve<T>() {
                    return _context.Resolve<T>();
                }
            }

        }








        public void RunStartUpTasks() {
            //Gather start-up tasks
            //...

            //run 'em
            //...
        }


        public void Initialize(NopConfig config) {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type) {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>() {
            return ContainerManager.ResolveAll<T>();
        }
    }
}
