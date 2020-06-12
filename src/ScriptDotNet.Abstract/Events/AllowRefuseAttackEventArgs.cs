using System;

namespace ScriptDotNet
{
    public class AllowRefuseAttackEventArgs : EventArgs
    {
        public AllowRefuseAttackEventArgs(int targetId, bool isAttackOk)
        {
            TargetId = targetId;
            IsAttackOK = isAttackOk;
        }
        public int TargetId { get; private set; }
        public bool IsAttackOK { get; private set; }
    }


}
