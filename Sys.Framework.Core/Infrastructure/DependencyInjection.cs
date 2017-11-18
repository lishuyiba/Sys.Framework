using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sys.Framework.Core.Infrastructure
{
    public class DependencyInjection
    {
        public static void Execute(Assembly assembly)
        {
            var builder = new ContainerBuilder();
            TypeFinder typeFinder = new TypeFinder();
            var result = typeFinder.FindClassesOfType<IDependencyRegistrar>().ToArray();
            List<IDependencyRegistrar> list = new List<IDependencyRegistrar>();
            foreach (var dr in result)
            {
                list.Add((IDependencyRegistrar)Activator.CreateInstance(dr));
            }
            foreach (var dr in list)
            {
                dr.Register(builder);
            }
            builder.RegisterControllers(assembly);
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            var container = builder.Build();
            EngineContext.Initialize().SetContainer(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
