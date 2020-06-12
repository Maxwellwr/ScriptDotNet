using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public abstract class BaseService
    {
        protected IStealthClient _client;

        public BaseService(IStealthClient client)
        {
            _client = client;
        }
    }
}
