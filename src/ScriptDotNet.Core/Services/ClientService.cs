using ScriptDotNet.Network;
using System;

namespace ScriptDotNet.Services
{
    public class ClientService: BaseService, IClientService
    {
        public ClientService(IStealthClient client)
            :base(client)
        {

        }

        public bool ClientHide(uint id)
        {
            throw new NotImplementedException();
        }

        public void ClientPrint(string text)
        {
            _client.SendPacket(PacketType.SCClientPrint, text);
        }

        public void ClientPrintEx(uint senderId, ushort color, ushort font, string text)
        {
            _client.SendPacket(PacketType.SCClientPrintEx, senderId, color, font, text);
        }

        public void CloseClientUIWindow(UIWindowType uiWindowType, uint id)
        {
            _client.SendPacket(PacketType.SCCloseClientUIWindow, uiWindowType, id);
        }

        public void UOSay(string text)
        {
            _client.SendPacket(PacketType.SCSendTextToUO, text);
        }

        public void UOSayColor(string text, ushort color)
        {
            _client.SendPacket(PacketType.SCSendTextToUOColor, text, color);
        }
    }
}
