// -----------------------------------------------------------------------
// <copyright file="JournalService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class JournalService : BaseService, IJournalService
    {
        public JournalService(IStealthClient client)
            : base(client)
        {
        }

        public int FoundedParamID
        {
            get { return Client.SendPacket<int>(PacketType.SCGetFoundedParamID); }
        }

        public int HighJournal
        {
            get { return Client.SendPacket<int>(PacketType.SCHighJournal); }
        }

        public string LastJournalMessage
        {
            get { return Client.SendPacket<string>(PacketType.SCLastJournalMessage); }
        }

        public int LineCount
        {
            get { return Client.SendPacket<int>(PacketType.SCGetLineCount); }
        }

        public uint LineID
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetLineID); }
        }

        public int LineIndex
        {
            get { return Client.SendPacket<int>(PacketType.SCGetLineIndex); }
        }

        public byte LineMsgType
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetLineMsgType); }
        }

        public string LineName
        {
            get { return Client.SendPacket<string>(PacketType.SCGetLineName); }
        }

        public ushort LineTextColor
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetLineTextColor); }
        }

        public ushort LineTextFont
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetLineTextFont); }
        }

        public DateTime LineTime
        {
            get { return Client.SendPacket<DateTime>(PacketType.SCGetLineTime); }
        }

        public ushort LineType
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetLineType); }
        }

        public int LowJournal
        {
            get { return Client.SendPacket<int>(PacketType.SCLowJournal); }
        }

        public void AddChatUserIgnore(string user)
        {
            Client.SendPacket(PacketType.SCUAddChatUserIgnore, user);
        }

        public void AddJournalIgnore(string str)
        {
            Client.SendPacket(PacketType.SCAddJournalIgnore, str);
        }

        public void AddToDebugJournal(string msg)
        {
            throw new NotImplementedException();
        }

        public void AddToJournal(string text)
        {
            Client.SendPacket(PacketType.SCAddToJournal, text);
        }

        public void AddToSystemJournal(string text)
        {
            Client.SendPacket(PacketType.SCAddToSystemJournal, text);
        }

        public void AddToSystemJournal(string format, params object[] args)
        {
            AddToSystemJournal(string.Format(format, args));
        }

        public void ClearChatUserIgnore()
        {
            Client.SendPacket(PacketType.SCClearChatUserIgnore);
        }

        public void ClearJournal()
        {
            Client.SendPacket(PacketType.SCClearJournal);
        }

        public void ClearJournalIgnore()
        {
            Client.SendPacket(PacketType.SCClearJournalIgnore);
        }

        public void ClearSystemJournal()
        {
            Client.SendPacket(PacketType.SCClearSystemJournal);
        }

        public int InJournal(string str)
        {
            return Client.SendPacket<int>(PacketType.SCInJournal, str);
        }

        public int InJournalBetweenTimes(string str, DateTime timeBegin, DateTime timeEnd)
        {
            return Client.SendPacket<int>(PacketType.SCInJournalBetweenTimes, str, timeBegin, timeEnd);
        }

        public string Journal(int stringIndex)
        {
            return Client.SendPacket<string>(PacketType.SCJournal, stringIndex);
        }

        public void SetJournalLine(int stringIndex, string text)
        {
            Client.SendPacket(PacketType.SCSetJournalLine, stringIndex, text);
        }

        public bool WaitJournalLine(DateTime startTime, string str, int maxWaitTimeMS = 0)
        {
            bool infinite = maxWaitTimeMS <= 0;
            DateTime stopTime = startTime.AddMilliseconds(maxWaitTimeMS);

            do
            {
                if (InJournalBetweenTimes(str, startTime, infinite ? DateTime.Now : stopTime) >= 0)
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(20);
                }
            }
            while (infinite || (stopTime > DateTime.Now));
            return false;
        }

        public bool WaitJournalLineSystem(DateTime startTime, string str, int maxWaitTimeMS = 0)
        {
            bool infinite = maxWaitTimeMS <= 0;
            DateTime stopTime = startTime.AddMilliseconds(maxWaitTimeMS);

            do
            {
                if ((InJournalBetweenTimes(str, startTime, infinite ? DateTime.Now : stopTime) >= 0)
                && LineName.Equals("System"))
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(20);
                }
            }
            while (infinite || (stopTime > DateTime.Now));
            return false;
        }
    }
}
