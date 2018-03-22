using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Common
{
    public enum RejectMoveItemReason : byte
    {
        CanNotPickUp = 0,
        TooFarAway = 1,
        OutOfSight = 2,
        DoesNotBelong = 3,
        AlreadyHolding = 4,
        MustWait = 5
    }
}
