using ScriptDotNet2.Common;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class GlobalService:BaseService, IGlobalService
    {
        public GlobalService(StealthClient client)
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
