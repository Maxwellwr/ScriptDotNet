using System;

namespace ScriptDotNet
{
    public class ClilocSpeechEventArgs : EventArgs
    {
        public ClilocSpeechEventArgs(int senderId, string senderName, int clilocId, string text)
        {
            SenderId = senderId;
            SenderName = senderName;
            ClilocId = clilocId;
            Text = text;
        }
        public int SenderId { get; private set; }
        public string SenderName { get; private set; }
        public int ClilocId { get; private set; }
        public string Text { get; private set; }
    }


}
