using System;

namespace ScriptDotNet
{
    public class ICQErrorEventArgs : EventArgs
    {
        public ICQErrorEventArgs(string text)
        {
            Text = text;
        }
        public string Text { get; private set; }
    }


}
