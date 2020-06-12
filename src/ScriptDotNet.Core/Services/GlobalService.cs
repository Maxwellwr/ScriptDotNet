using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class GlobalService:BaseService, IGlobalService
    {
        public GlobalService(IStealthClient client)
            :base(client)
        {

        }

        public void SetGlobal(VarRegion globalRegion, string varName, string varValue)
        {
            _client.SendPacket(PacketType.SCSetGlobal, globalRegion, varName, varValue);
        }
        public string GetGlobal(VarRegion globalRegion, string varName)
        {
            return _client.SendPacket<string>(PacketType.SCGetGlobal, globalRegion, varName);
        }
    }
}
