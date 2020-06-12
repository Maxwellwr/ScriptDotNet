using ScriptDotNet.Network;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScriptDotNet.Services
{
    public class JournalService : BaseService, IJournalService
    {
        //private Task _monitor;
        //private CancellationTokenSource _cancel = new CancellationTokenSource();

        //private event EventHandler<string> _onNewLine;
        //public event EventHandler<string> OnNewLine
        //{
        //    add
        //    {
        //        if (_onNewLine == null)
        //        {
        //            _monitor = Monitor(_cancel.Token);
        //        }

        //        _onNewLine += value;
        //    }
        //    remove
        //    {
        //        _onNewLine -= value;

        //        if (_onNewLine == null)
        //        {
        //            _cancel.Cancel();
        //            _monitor.Wait();
        //        }
        //    }
        //}


        public JournalService(IStealthClient client)
            : base(client)
        {

        }

        //private async Task Monitor(CancellationToken token)
        //{
        //    var lastId = LineCount;
        //    while (!token.IsCancellationRequested)
        //    {
        //        if (LineCount != lastId)
        //        {
        //            var msg = Journal(lastId);
        //            _onNewLine?.Invoke(this, msg);
        //        }
        //        else
        //            await Task.Delay(20, token);
        //    }
        //    token.ThrowIfCancellationRequested();
        //}

        public int FoundedParamID
        {
            get { return _client.SendPacket<int>(PacketType.SCGetFoundedParamID); }
        }

        public int HighJournal
        {
            get { return _client.SendPacket<int>(PacketType.SCHighJournal); }
        }

        public string LastJournalMessage
        {
            get { return _client.SendPacket<string>(PacketType.SCLastJournalMessage); }
        }

        public int LineCount
        {
            get { return _client.SendPacket<int>(PacketType.SCGetLineCount); }
        }

        public uint LineID
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLineID); }
        }

        public int LineIndex
        {
            get { return _client.SendPacket<int>(PacketType.SCGetLineIndex); }
        }

        public byte LineMsgType
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetLineMsgType); }
        }

        public string LineName
        {
            get { return _client.SendPacket<string>(PacketType.SCGetLineName); }
        }

        public ushort LineTextColor
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetLineTextColor); }
        }

        public ushort LineTextFont
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetLineTextFont); }
        }

        public DateTime LineTime
        {
            get { return _client.SendPacket<DateTime>(PacketType.SCGetLineTime); }
        }

        public ushort LineType
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetLineType); }
        }

        public int LowJournal
        {
            get { return _client.SendPacket<int>(PacketType.SCLowJournal); }
        }

        public void AddChatUserIgnore(string user)
        {
            _client.SendPacket(PacketType.SCUAddChatUserIgnore, user);
        }

        public void AddJournalIgnore(string str)
        {
            _client.SendPacket(PacketType.SCAddJournalIgnore, str);
        }

        public void AddToDebugJournal(string Msg)
        {
            throw new NotImplementedException();
        }

        public void AddToJournal(string text)
        {
            _client.SendPacket(PacketType.SCAddToJournal, text);
        }

        public void AddToSystemJournal(string text)
        {
            _client.SendPacket(PacketType.SCAddToSystemJournal, text);
        }

        public void AddToSystemJournal(string format, params object[] args)
        {
            AddToSystemJournal(string.Format(format, args));
        }

        public void ClearChatUserIgnore()
        {
            _client.SendPacket(PacketType.SCClearChatUserIgnore);
        }

        public void ClearJournal()
        {
            _client.SendPacket(PacketType.SCClearJournal);
        }

        public void ClearJournalIgnore()
        {
            _client.SendPacket(PacketType.SCClearJournalIgnore);
        }

        public void ClearSystemJournal()
        {
            _client.SendPacket(PacketType.SCClearSystemJournal);
        }

        public int InJournal(string str)
        {
            return _client.SendPacket<int>(PacketType.SCInJournal, str);
        }

        public int InJournalBetweenTimes(string str, DateTime timeBegin, DateTime timeEnd)
        {
            return _client.SendPacket<int>(PacketType.SCInJournalBetweenTimes, str, timeBegin, timeEnd);
        }

        public string Journal(int stringIndex)
        {
            return _client.SendPacket<string>(PacketType.SCJournal, stringIndex);
        }

        public void SetJournalLine(int stringIndex, string text)
        {
            _client.SendPacket(PacketType.SCSetJournalLine, stringIndex, text);
        }

        public bool WaitJournalLine(DateTime startTime, string str, int maxWaitTimeMS = 0)
        {
            bool infinite = maxWaitTimeMS <= 0;
            DateTime stopTime = startTime.AddMilliseconds(maxWaitTimeMS);

            do
            {
                if (InJournalBetweenTimes(str, startTime, infinite ? DateTime.Now : stopTime) >= 0)
                    return true;
                else
                    Thread.Sleep(20);
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
                    return true;
                else
                    Thread.Sleep(20);
            }
            while (infinite || (stopTime > DateTime.Now));
            return false;
        }
    }
}
