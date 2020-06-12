using System;

namespace ScriptDotNet
{
    public class ItemEventArgs : EventArgs
    {
        public ItemEventArgs(uint itemId)
        {
            ItemId = itemId;
        }
        public uint ItemId { get; private set; }
    }


}
