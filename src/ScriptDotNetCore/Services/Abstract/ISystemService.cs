using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface ISystemService
    {
        bool SilentMode { get; set; }

        void Alarm();
        void Beep();
        void ConsoleEntryReply(string Text);
        void ConsoleEntryUnicodeReply(string Text);
        void HelpRequest();
        void QuestRequest();
        void RequestStats(uint ObjID);
        void SetCmdPrefix(char prefix);
        int SendMessageToWindow(IntPtr WindowHandle, uint CharID, byte[] ByteArr);
        void ShowMessage(string Msg);
        ushort Sign(int AValue);
    }
}
