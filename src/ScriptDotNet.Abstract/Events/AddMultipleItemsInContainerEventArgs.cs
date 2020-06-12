using System;

namespace ScriptDotNet
{
    public class AddMultipleItemsInContainerEventArgs : EventArgs
    {
        public AddMultipleItemsInContainerEventArgs(uint containerId)
        {
            ContainerId = containerId;
        }
        public uint ContainerId { get; private set; }
    }


}
