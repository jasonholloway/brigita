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
using System.Reflection;

namespace Brigita.Infrastructure
{
    public class BrigitaEngine : IEngine
    {
        NopConfig _config;
        ITypeFinder _typeFinder;
        IScanner _scanner = new Scanner();


        public ContainerManager ContainerManager { get; private set; }

        public BrigitaEngine() {
            _config = ConfigurationManager.GetSection("NopConfig") as NopConfig;
            _typeFinder = new WebAppTypeFinder(_config);
        }


        public void BuildContainer(params Assembly[] rAssemblies) {
            BuildContainer(rAssemblies.AsEnumerable());
        }


        public void BuildContainer(IEnumerable<Assembly> assemblies) 
        {
            IContainer container = null;

            var x = new ContainerBuilder();

            //x.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            x.RegisterInstance(_config)
                .As<NopConfig>().SingleInstance();

            x.RegisterInstance(this)
                .As<IEngine>().SingleInstance();

            x.RegisterInstance(_typeFinder)
                .As<ITypeFinder>().SingleInstance();
                        

            var binder = new BinderAdaptor(x);
            //x.RegisterInstance(binder)
            //    .As<IBinder>().SingleInstance();


            x.Register(c => new ResolverAdaptor(c.Resolve<IComponentContext>()))
                .As<IResolver>();

            var registrarTypes = _scanner.ScanTypes(assemblies)
                                    .Where(t => !t.IsAbstract 
                                                && t.IsAssignableTo<IRegistrar>());

            foreach(var registrarType in registrarTypes) {
                var registrar = (IRegistrar)Activator.CreateInstance(registrarType);
                registrar.Register(binder, _scanner);
            }



            container = x.Build();

           


            ContainerManager = new ContainerManager(container);

            DependencyResolver.SetResolver(
                                    new AutofacDependencyResolver(ContainerManager.Container)
                                    );
        }









        class ResolverAdaptor : IResolver
        {
            IComponentContext _ctx;

            public ResolverAdaptor(IComponentContext ctx) {
                _ctx = ctx;
            }

            public T Resolve<T>() {
                return _ctx.Resolve<T>();
            }
        }


        class BinderAdaptor : IBinder
        {
            ContainerBuilder _builder;

            public BinderAdaptor(ContainerBuilder builder) {
                _builder = builder;
            }
            
            public void Bind(Type type, object instance) 
            {
                _builder.RegisterInstance(instance)
                                .As(type)
                                .InstancePerLifetimeScope();     
            }
            
            public void Bind(Type type, Func<IResolver, object> fnFactory) 
            {
                _builder.Register(c => fnFactory(new ContCtxAdaptor(c)))
                                .As(type)
                                .InstancePerLifetimeScope();
            }

            public void Bind(Type intType, Type implType) 
            {
                _builder.RegisterType(implType)
                            .As(intType)
                            .InstancePerLifetimeScope();
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

            public void Bind<T>(Func<IResolver, T> fnFactory) {
                _builder.Register<T>(c => fnFactory(new ContCtxAdaptor(c)))
                            .InstancePerLifetimeScope();
            }

            public void BindSingleton<T>(T instance) {
                _builder.Register<T>(_ => instance)
                            .SingleInstance();
            }

            public void BindSingleton<T>(Func<IResolver, T> fnFactory) {
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

            public void BindGenericSingleton(Type intType, Type impType) {
                _builder.RegisterGeneric(impType)
                                .As(intType)
                                .SingleInstance();
            }


            public void BindTransient<T, TImp>() where TImp : T {
                _builder.RegisterType<TImp>()
                                .As<T>()
                                .InstancePerDependency();
            }

            public void BindTransient<T>(Func<IResolver, T> fnFactory) {
                _builder.Register<T>(c => fnFactory(new ContCtxAdaptor(c)))
                            .InstancePerDependency();
            }


            class ContCtxAdaptor : IResolver
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







        public void RunStartUpTasks(IEnumerable<Assembly> assemblies) 
        {
            var taskTypes = _scanner.ScanTypes(assemblies)
                                        .Where(t => !t.IsAbstract
                                                    && typeof(IStartupTask).IsAssignableFrom(t));

            var tasks = taskTypes
                            .Select(type => (IStartupTask)Activator.CreateInstance(type))
                            .OrderBy(task => task.Order);

            foreach(var task in tasks) {
                task.Run();
            }
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
