using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Parameters;

namespace ScriptDotNet2.Services
{
    public static class ServiceManager
    {
        static IKernel _kernel;

        static ServiceManager()
        {
            _kernel = new StandardKernel(new StealthModule());
        }
        public static T GetService<T>()
        {
            return _kernel.Get<T>();
        }

        public static void SetClient(StealthClient _client)
        {
            _kernel.Bind<StealthClient>().ToConstant(_client);
        }
    }
}
