using System;

namespace ScriptDotNet
{
    public class ICQIncomingTextEventArgs : EventArgs
    {
        public ICQIncomingTextEventArgs(uint uin, string text)
        {
            UIN = uin;
            Text = text;
        }
        public uint UIN { get; private set; }
        public string Text { get; private set; }
    }


}
