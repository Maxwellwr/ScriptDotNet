using System;

namespace ScriptDotNet
{
    public class DeathEventArgs : EventArgs
    {
        public DeathEventArgs(bool isDead)
        {
            IsDead = isDead;
        }
        public bool IsDead { get; private set; }
    }


}
