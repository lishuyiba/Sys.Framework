using Autofac;
using Sys.Framework.Core.Infrastructure;
using Sys.Framework.Service.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Service
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<RoleService>().As<IRoleService>().SingleInstance();
            builder.RegisterType<AcceptService>().As<IAcceptService>().SingleInstance();
            builder.RegisterType<BusinessService>().As<IBusinessService>().SingleInstance();
        }
    }
}
