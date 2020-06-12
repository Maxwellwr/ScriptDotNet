namespace ScriptDotNet
{
    public class MessangerIncomingTextEventArgs : MessangerTextEventArgs
    {
        public MessangerIncomingTextEventArgs(MessangerType messangerType, string senderNickname, string senderId, string chatId, string eventMsg, MessangerEventType eventCode)
            : base(senderNickname, senderId, chatId, eventMsg)
        {
            MessangerType = messangerType;
            EventCode = eventCode;
        }
        public MessangerType MessangerType { get; set; }
        public MessangerEventType EventCode { get; set; }
    }


}
