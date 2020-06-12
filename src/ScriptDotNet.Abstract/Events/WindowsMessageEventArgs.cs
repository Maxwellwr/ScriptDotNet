using System;

namespace ScriptDotNet
{
    public class WindowsMessageEventArgs : EventArgs
    {
        public WindowsMessageEventArgs(int lParam)
        {
            LParam = lParam;
        }
        public int LParam { get; private set; }
    }


}
