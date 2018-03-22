using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class InfoWindowService:BaseService, IInfoWindowService
    {
        public InfoWindowService(StealthClient client)
            :base(client)
        {

        }

        public void ClearInfoWindow()
        {
            _client.SendPacket(PacketType.SCClearInfoWindow);
        }

        public void FillInfoWindow(string str)
        {
            _client.SendPacket(PacketType.SCFillNewWindow, str);
        }
    }
}
