using System;

namespace ScriptDotNet
{
    public class AddMultipleItemsInContainerEventArgs : EventArgs
    {
        public AddMultipleItemsInContainerEventArgs(int containerId)
        {
            ContainerId = containerId;
        }
        public int ContainerId { get; private set; }
    }


}
