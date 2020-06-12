using System;

namespace ScriptDotNet
{
    public class DrawContainerEventArgs : EventArgs
    {
        public DrawContainerEventArgs(int containerId, ushort modelGump)
        {
            ContainerId = containerId;
            ModelGump = modelGump;
        }
        public int ContainerId { get; private set; }
        public ushort ModelGump { get; private set; }
    }


}
