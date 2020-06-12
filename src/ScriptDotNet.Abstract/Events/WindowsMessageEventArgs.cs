using System;

namespace ScriptDotNet
{
    public class WindowsMessageEventArgs : EventArgs
    {
        public WindowsMessageEventArgs(uint lParam)
        {
            LParam = lParam;
        }
        public uint LParam { get; private set; }
    }


}
