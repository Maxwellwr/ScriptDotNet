using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class GestureService:BaseService, IGestureService
    {
        public GestureService(StealthClient client)
            :base(client)
        {

        }

        public void Bow()
        {
            _client.SendPacket(PacketType.SCBow);

        }
        public void Salute()
        {
            _client.SendPacket(PacketType.SCSalute);

        }
    }
}
