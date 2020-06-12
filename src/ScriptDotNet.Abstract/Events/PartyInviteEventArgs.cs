using System;

namespace ScriptDotNet
{
    public class PartyInviteEventArgs : EventArgs
    {
        public PartyInviteEventArgs(uint inviterId)
        {
            InviterId = inviterId;
        }
        public uint InviterId { get; private set; }
    }


}
