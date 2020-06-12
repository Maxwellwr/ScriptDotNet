using System;

namespace ScriptDotNet
{
    public class PartyInviteEventArgs : EventArgs
    {
        public PartyInviteEventArgs(int inviterId)
        {
            InviterId = inviterId;
        }
        public int InviterId { get; private set; }
    }


}
