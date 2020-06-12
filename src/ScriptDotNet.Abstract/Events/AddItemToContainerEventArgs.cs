namespace ScriptDotNet
{
    public class AddItemToContainerEventArgs : ItemEventArgs
    {
        public AddItemToContainerEventArgs(int itemId, int containerId)
            : base(itemId)
        {
            ContainerId = containerId;
        }
        public int ContainerId { get; private set; }
    }


}
