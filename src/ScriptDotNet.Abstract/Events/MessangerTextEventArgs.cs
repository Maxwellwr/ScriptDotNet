// -----------------------------------------------------------------------
// <copyright file="MessangerTextEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class MessangerTextEventArgs : MessangerErrorEventArgs
    {
        public MessangerTextEventArgs(string senderNickname, string senderId, string chatId, string eventMsg)
            : base(eventMsg)
        {
            SenderNickname = senderNickname;
            SenderId = senderId;
            ChatId = chatId;
        }

        public string SenderNickname { get; private set; }

        public string SenderId { get; private set; }

        public string ChatId { get; private set; }
    }
}
