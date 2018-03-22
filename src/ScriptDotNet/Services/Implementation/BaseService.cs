using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptDotNet2.Services
{
    public abstract class BaseService
    {
        protected StealthClient _client;

        public BaseService(StealthClient client)
        {
            _client = client;
        }

        protected T GetService<T>()
        {
            return ServiceManager.GetService<T>();
        }
    }
}
