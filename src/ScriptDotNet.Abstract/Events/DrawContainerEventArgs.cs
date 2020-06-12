using System;

namespace ScriptDotNet
{
    public class DrawContainerEventArgs : EventArgs
    {
        public DrawContainerEventArgs(uint containerId, ushort modelGump)
        {
            ContainerId = containerId;
            ModelGump = modelGump;
        }
        public uint ContainerId { get; private set; }
        public ushort ModelGump { get; private set; }
    }


}
