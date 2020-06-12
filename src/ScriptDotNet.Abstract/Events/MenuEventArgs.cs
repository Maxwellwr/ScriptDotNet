using System;

namespace ScriptDotNet
{
    public class MenuEventArgs : EventArgs
    {
        public MenuEventArgs(int dialogId, ushort menuId)
        {
            DialogId = dialogId;
            MenuId = menuId;
        }
        public int DialogId { get; private set; }
        public ushort MenuId { get; private set; }
    }


}
