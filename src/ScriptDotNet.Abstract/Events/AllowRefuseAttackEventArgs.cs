using System;

namespace ScriptDotNet
{
    public class AllowRefuseAttackEventArgs : EventArgs
    {
        public AllowRefuseAttackEventArgs(uint targetId, bool isAttackOk)
        {
            TargetId = targetId;
            IsAttackOK = isAttackOk;
        }
        public uint TargetId { get; private set; }
        public bool IsAttackOK { get; private set; }
    }


}
