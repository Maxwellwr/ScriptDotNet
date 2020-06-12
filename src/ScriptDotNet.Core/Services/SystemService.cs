using ScriptDotNet.Network;
using System;

namespace ScriptDotNet.Services
{
    public class SystemService: BaseService,ISystemService
    {
        public SystemService(IStealthClient client)
            :base(client)
        {

        }

        public bool SilentMode
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetSilentMode); }
            set { _client.SendPacket(PacketType.SCSetSilentMode, value); }
        }

        public void Alarm()
        {
            _client.SendPacket(PacketType.SCSetAlarm);
        }

        public void Beep()
        {
            throw new NotImplementedException();
        }

        public void ConsoleEntryReply(string text)
        {
            _client.SendPacket(PacketType.SCConsoleEntryReply, text);
        }

        public void ConsoleEntryUnicodeReply(string text)
        {
            _client.SendPacket(PacketType.SCConsoleEntryUnicodeReply, text);
        }

        public void HelpRequest()
        {
            _client.SendPacket(PacketType.SCHelpRequest);
        }
        
        public void QuestRequest()
        {
            _client.SendPacket(PacketType.SCQuestRequest);
        }

        public void RequestStats(uint objId)
        {
            _client.SendPacket(PacketType.SCRequestStats, objId);
        }

        public void SetCmdPrefix(char prefix)
        {
            throw new NotImplementedException();
        }
        
        public int SendMessageToWindow(IntPtr windowHandle, uint CharID, byte[] ByteArr)
        {
            throw new NotImplementedException();
            //Win32.SendMessage(windowHandle, )
        }

        public void ShowMessage(string Msg)
        {
            throw new NotImplementedException();
        }

        public ushort Sign(int AValue)
        {
            throw new NotImplementedException();
        }
    }
}
