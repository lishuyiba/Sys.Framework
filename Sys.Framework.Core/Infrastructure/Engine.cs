using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Core.Infrastructure
{
    public class Engine : IEngine
    {
        private ContainerManager _containerManager;
        public void SetContainer(IContainer container)
        {
            _containerManager = new ContainerManager(container);
        }
        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }
        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
            set { _containerManager = value; }
        }
    }
}
