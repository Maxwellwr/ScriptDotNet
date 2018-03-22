using Ninject.Modules;
using ScriptDotNet2.Network;
using ScriptDotNet2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2
{
    public class StealthModule:NinjectModule
    {
        public override void Load()
        {
            foreach (var intf in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsInterface && t.Name.EndsWith("Service")))
            {
                var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                    .Where(p => intf.IsAssignableFrom(p) && p.IsSubclassOf(typeof(BaseService))).FirstOrDefault();
                if (type != null)
                    Bind(intf).To(type).InSingletonScope();
            }
        }
    }
}
