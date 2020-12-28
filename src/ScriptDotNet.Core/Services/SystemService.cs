// -----------------------------------------------------------------------
// <copyright file="SystemService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;

namespace ScriptDotNet.Services
{
    public class SystemService : BaseService, ISystemService
    {
        public SystemService(IStealthClient client)
            : base(client)
        {
        }

        public bool SilentMode
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetSilentMode); }
            set { Client.SendPacket(PacketType.SCSetSilentMode, value); }
        }

        public void Alarm()
        {
            Client.SendPacket(PacketType.SCSetAlarm);
        }

        public void Beep()
        {
            throw new NotImplementedException();
        }

        public void ConsoleEntryReply(string text)
        {
            Client.SendPacket(PacketType.SCConsoleEntryReply, text);
        }

        public void ConsoleEntryUnicodeReply(string text)
        {
            Client.SendPacket(PacketType.SCConsoleEntryUnicodeReply, text);
        }

        public void HelpRequest()
        {
            Client.SendPacket(PacketType.SCHelpRequest);
        }

        public void QuestRequest()
        {
            Client.SendPacket(PacketType.SCQuestRequest);
        }

        public void RequestStats(uint objId)
        {
            Client.SendPacket(PacketType.SCRequestStats, objId);
        }

        public void SetCmdPrefix(char prefix)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public ushort Sign(int aValue)
        {
            throw new NotImplementedException();
        }
    }
}
