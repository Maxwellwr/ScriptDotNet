using System;

namespace ScriptDotNet
{
    public class ICQIncomingTextEventArgs : EventArgs
    {
        public ICQIncomingTextEventArgs(int uin, string text)
        {
            UIN = uin;
            Text = text;
        }
        public int UIN { get; private set; }
        public string Text { get; private set; }
    }


}
