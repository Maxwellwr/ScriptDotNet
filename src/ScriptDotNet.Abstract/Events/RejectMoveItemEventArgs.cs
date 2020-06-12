using System;

namespace ScriptDotNet
{
    public class RejectMoveItemEventArgs : EventArgs
    {
        public RejectMoveItemEventArgs(RejectMoveItemReason reason)
        {
            Reason = reason;
        }
        public RejectMoveItemReason Reason { get; private set; }
    }


}
