using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Core.Infrastructure
{
    public class EngineContext
    {
        protected static IEngine CreateEngineInstance()
        {
            return Activator.CreateInstance(typeof(Engine)) as IEngine;
        }
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = CreateEngineInstance();
            }
            return Singleton<IEngine>.Instance;
        }
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize();
                }
                return Singleton<IEngine>.Instance;
            }
        }
    }
}
