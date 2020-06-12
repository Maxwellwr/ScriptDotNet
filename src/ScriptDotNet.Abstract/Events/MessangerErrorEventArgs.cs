using System;

namespace ScriptDotNet
{
    public class MessangerErrorEventArgs: EventArgs
    {
        public MessangerErrorEventArgs(string eventMsg)
        {
            Message = eventMsg;
        }
        public string Message { get; private set; }
    }


}
