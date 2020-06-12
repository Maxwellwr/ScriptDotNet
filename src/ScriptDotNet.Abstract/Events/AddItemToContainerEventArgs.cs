namespace ScriptDotNet
{
    public class AddItemToContainerEventArgs : ItemEventArgs
    {
        public AddItemToContainerEventArgs(uint itemId, uint containerId)
            : base(itemId)
        {
            ContainerId = containerId;
        }
        public uint ContainerId { get; private set; }
    }


}
