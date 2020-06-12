using System;

namespace ScriptDotNet
{
    public class SpeechEventArgs : EventArgs
    {
        public SpeechEventArgs(string text, string senderName, int senderId)
        {
            Text = text;
            SenderName = senderName;
            SenderId = senderId;
        }
        public string Text { get; private set; }
        public string SenderName { get; private set; }
        public int SenderId { get; private set; }
    }


}
