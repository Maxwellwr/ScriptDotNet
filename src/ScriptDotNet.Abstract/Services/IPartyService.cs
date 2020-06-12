namespace ScriptDotNet.Services
{
    public interface IPartyService
    {
        bool InParty { get; }
        uint[] PartyMembersList { get; }

        void InviteToParty(uint ID);
        void PartyAcceptInvite();
        void PartyCanLootMe(bool Value);
        void PartyDeclineInvite();
        void PartyLeave();
        void PartyPrivateMessageTo(uint ID, string Msg);
        void PartySay(string Msg);
        void RemoveFromParty(uint ID);
    }
}
