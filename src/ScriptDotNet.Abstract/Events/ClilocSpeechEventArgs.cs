// -----------------------------------------------------------------------
// <copyright file="ClilocSpeechEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class ClilocSpeechEventArgs : EventArgs
    {
        public ClilocSpeechEventArgs(uint senderId, string senderName, uint clilocId, string text)
        {
            SenderId = senderId;
            SenderName = senderName;
            ClilocId = clilocId;
            Text = text;
        }

        public uint SenderId { get; private set; }

        public string SenderName { get; private set; }

        public uint ClilocId { get; private set; }

        public string Text { get; private set; }
    }
}
