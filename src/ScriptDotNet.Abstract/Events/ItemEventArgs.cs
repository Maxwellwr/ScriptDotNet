using System;

namespace ScriptDotNet
{
    public class ItemEventArgs : EventArgs
    {
        public ItemEventArgs(int itemId)
        {
            ItemId = itemId;
        }
        public int ItemId { get; private set; }
    }


}
