using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class GestureService:BaseService, IGestureService
    {
        public GestureService(IStealthClient client)
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
