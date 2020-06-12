using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class InfoWindowService:BaseService, IInfoWindowService
    {
        public InfoWindowService(IStealthClient client)
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
