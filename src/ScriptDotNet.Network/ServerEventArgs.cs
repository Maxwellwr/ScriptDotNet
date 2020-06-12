using System;

namespace ScriptDotNet.Network
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
