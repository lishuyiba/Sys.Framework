using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Core.Infrastructure
{
    public interface IEngine
    {
        void SetContainer(IContainer container);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
    }
}
