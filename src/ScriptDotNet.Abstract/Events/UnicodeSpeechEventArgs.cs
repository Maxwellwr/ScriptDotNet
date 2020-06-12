using System;

namespace ScriptDotNet
{
    public class UnicodeSpeechEventArgs : EventArgs
    {
        public UnicodeSpeechEventArgs(string text, string senderName, uint senderId)
        {
            Text = text;
            SenderName = senderName;
            SenderId = senderId;
        }
        public string Text { get; private set; }
        public string SenderName { get; private set; }
        public uint SenderId { get; private set; }
    }


}
