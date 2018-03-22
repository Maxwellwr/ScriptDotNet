using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Common
{
    public enum MessangerEventType:byte
    {
        Connected = 0,
        Disconnected = 1,
        Message = 2,
        Error = 3
    }
}
