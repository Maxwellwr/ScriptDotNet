using System;

namespace ScriptDotNet
{
    public class MenuEventArgs : EventArgs
    {
        public MenuEventArgs(uint dialogId, ushort menuId)
        {
            DialogId = dialogId;
            MenuId = menuId;
        }
        public uint DialogId { get; private set; }
        public ushort MenuId { get; private set; }
    }


}
