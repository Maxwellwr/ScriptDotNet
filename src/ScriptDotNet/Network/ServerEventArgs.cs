using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Network
{
    public class ServerEventArgs : EventArgs
    {
        public ServerEventArgs()
        {
        }

        public ServerEventArgs(ExecEventProcData data)
        {
            Data = data;
        }
        public ExecEventProcData Data { get; set; }
    }
}
