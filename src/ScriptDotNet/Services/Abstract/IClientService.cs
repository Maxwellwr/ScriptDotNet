using ScriptDotNet2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IClientService
    {
        bool ClientHide(uint ID);
        void ClientPrint(string Text);
        void ClientPrintEx(uint SenderID, ushort Color, ushort Font, string Text);
        void CloseClientUIWindow(UIWindowType UIWindowType, uint ID);
        void UOSay(string Text);
        void UOSayColor(string Text, ushort Color);
        
    }
}
