using System;

namespace ScriptDotNet.Services
{
    public interface IJournalService
    {
        //event EventHandler<string> OnNewLine;

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

        void AddChatUserIgnore(string User);
        void AddJournalIgnore(string Str);
        void AddToDebugJournal(string text);
        void AddToJournal(string text);
        void AddToSystemJournal(string text);
        void AddToSystemJournal(string format, params object[] args);
        void ClearChatUserIgnore();
        void ClearJournal();
        void ClearJournalIgnore();
        void ClearSystemJournal();
        int InJournal(string Str);
        int InJournalBetweenTimes(string Str, DateTime TimeBegin, DateTime TimeEnd);
        string Journal(int stringIndex);
        void SetJournalLine(int stringIndex, string Text);
        bool WaitJournalLine(DateTime StartTime, string Str, int MaxWaitTimeMS = 0);
        bool WaitJournalLineSystem(DateTime StartTime, string Str, int MaxWaitTimeMS = 0);
    }
}
