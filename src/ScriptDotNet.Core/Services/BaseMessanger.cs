using ScriptDotNet.Network;
using System;

namespace ScriptDotNet.Services
{
    public abstract class BaseMessanger : BaseService, IMessangerBase
    {
        public BaseMessanger(IStealthClient client, IEventSystemService eventSystemService)
            : base(client)
        {
            eventSystemService.MessangerIncomingText += EventService_MessangerIncomingText;
        }

        private void EventService_MessangerIncomingText(object sender, MessangerIncomingTextEventArgs e)
        {
            if (e.MessangerType != MessangerType)
                return;

            switch (e.EventCode)
            {
                case MessangerEventType.Connected: //Connected
                    Connected?.Invoke(this, new EventArgs());
                    break;
                case MessangerEventType.Disconnected: //Disconnected
                    Disconnected?.Invoke(this, new EventArgs());
                    break;
                case MessangerEventType.Message: //Incoming Message
                    IncomingMessage?.Invoke(this, e as MessangerTextEventArgs);
                    break;
                case MessangerEventType.Error: //Error
                    Error?.Invoke(this, e as MessangerErrorEventArgs);
                    break;
            }
        }

        protected abstract MessangerType MessangerType { get; }
        public bool IsConnected
        {
            get => _client.SendPacket<bool>(PacketType.SCMessenger_GetConnected, MessangerType);
            private set => _client.SendPacket(PacketType.SCMessenger_SetConnected, MessangerType, value);
        }

        public string Token
        {
            get => _client.SendPacket<string>(PacketType.SCMessenger_GetToken, MessangerType);
            private set => _client.SendPacket(PacketType.SCMessenger_SetToken, MessangerType, value);
        }

        public string Name
        {
            get => _client.SendPacket<string>(PacketType.SCMessenger_GetName, MessangerType);
        }

        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<MessangerTextEventArgs> IncomingMessage;
        public event EventHandler<MessangerErrorEventArgs> Error;

        public void Connect(string token)
        {
            if (IsConnected)
                IsConnected = false;

            Token = token;
            IsConnected = true;
        }

        public void SendMessage(string message, string recieverId)
        {
            _client.SendPacket(PacketType.SCMessenger_SendMessage, MessangerType, message, recieverId);
        }
    }
}
