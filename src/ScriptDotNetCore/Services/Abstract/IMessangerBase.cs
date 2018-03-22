using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IMessangerBase
    {
        event EventHandler Connected;
        event EventHandler Disconnected;
        event EventHandler<MessangerTextEventArgs> IncomingMessage;
        event EventHandler<MessangerErrorEventArgs> Error;
        

        bool IsConnected { get; }
        string Token { get; }
        string Name { get; }
        void SendMessage(string message, string recieverId);
        void Connect(string token);
    }


}
