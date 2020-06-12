using System;

namespace ScriptDotNet
{
    public class IRCIncomingTextEventArgs : EventArgs
    {
        public IRCIncomingTextEventArgs(string text)
        {
            Text = text;
        }
        public string Text { get; private set; }
    }


}
