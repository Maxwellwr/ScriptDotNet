using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class ICQService:BaseService, IICQService
    {
        public ICQService(StealthClient client)
            :base(client)
        {

        }

        public bool ICQConnected
        {
            get { return _client.SendPacket<bool>(PacketType.SCICQ_GetConnectedStatus); }
        }

        public void ICQConnect(string uin, string password)
        {
            _client.SendPacket(PacketType.SCICQ_Connect, uin, password);
        }

        public void ICQDisconnect()
        {
            _client.SendPacket(PacketType.SCICQ_Disconnect);
        }

        public void ICQSendText(string toUin, string text)
        {
            _client.SendPacket(PacketType.SCICQ_SendText, toUin, text);
        }

        public void ICQSetStatus(byte num)
        {
            _client.SendPacket(PacketType.SCICQ_SetStatus, num);
        }

        public void ICQSetXStatus(byte num)
        {
            _client.SendPacket(PacketType.SCICQ_SetXStatus, num);
        }
    }
}
