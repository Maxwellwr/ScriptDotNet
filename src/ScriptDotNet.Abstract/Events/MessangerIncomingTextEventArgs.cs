// -----------------------------------------------------------------------
// <copyright file="MessangerIncomingTextEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
