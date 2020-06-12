using System;

namespace ScriptDotNet.Services
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
