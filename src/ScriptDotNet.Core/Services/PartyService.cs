using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class PartyService:BaseService, IPartyService
    {
        public PartyService(IStealthClient client)
            :base(client)
        {

        }

        public bool InParty
        {
            get { return _client.SendPacket<bool>(PacketType.SCInParty); }
        }

        public uint[] PartyMembersList
        {
            get { return _client.SendPacket<uint[]>(PacketType.SCPartyMembersList); }
        }

        public void InviteToParty(uint id)
        {
            _client.SendPacket(PacketType.SCInviteToParty, id);
        }

        public void PartyAcceptInvite()
        {
            _client.SendPacket(PacketType.SCPartyAcceptInvite);
        }

        public void PartyCanLootMe(bool value)
        {
            _client.SendPacket(PacketType.SCPartyCanLootMe, value);
        }

        public void PartyDeclineInvite()
        {
            _client.SendPacket(PacketType.SCPartyDeclineInvite);
        }

        public void PartyLeave()
        {
            _client.SendPacket(PacketType.SCPartyLeave);
        }

        public void PartyPrivateMessageTo(uint id, string msg)
        {
            _client.SendPacket(PacketType.SCPartyMessageTo, id, msg);
        }

        public void PartySay(string msg)
        {
            _client.SendPacket(PacketType.SCPartySay, msg);
        }

        public void RemoveFromParty(uint id)
        {
            _client.SendPacket(PacketType.SCRemoveFromParty, id);
        }
    }
}
