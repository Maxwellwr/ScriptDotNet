// -----------------------------------------------------------------------
// <copyright file="IJournalService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet.Services
{
    public interface IJournalService
    {
        int FoundedParamID { get; }

        int HighJournal { get; }

        string LastJournalMessage { get; }

        int LineCount { get; }

        uint LineID { get; }

        int LineIndex { get; }

        byte LineMsgType { get; }

        string LineName { get; }

        ushort LineTextColor { get; }

        ushort LineTextFont { get; }

        DateTime LineTime { get; }

        ushort LineType { get; }

        int LowJournal { get; }

        void AddChatUserIgnore(string user);

        void AddJournalIgnore(string str);

        void AddToDebugJournal(string text);

        void AddToJournal(string text);

        void AddToSystemJournal(string text);

        void AddToSystemJournal(string format, params object[] args);

        void ClearChatUserIgnore();

        void ClearJournal();

        void ClearJournalIgnore();

        void ClearSystemJournal();

        int InJournal(string str);

        int InJournalBetweenTimes(string str, DateTime timeBegin, DateTime timeEnd);

        string Journal(int stringIndex);

        void SetJournalLine(int stringIndex, string text);

        bool WaitJournalLine(DateTime startTime, string str, int maxWaitTimeMS = 0);

        bool WaitJournalLineSystem(DateTime startTime, string str, int maxWaitTimeMS = 0);
    }
}