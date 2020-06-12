using ScriptDotNet.Network;
using System;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class ConnectionService : BaseService, IConnectionService
    {
        public ConnectionService(IStealthClient client)
            : base(client)
        {

        }

        public bool ARStatus
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetARStatus); }
            set { _client.SendPacket(PacketType.SCSetPauseScriptOnDisconnectStatus, value); }
        }

        public bool Connected
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetConnectedStatus); }
        }

        public DateTime ConnectedTime
        {
            get { return _client.SendPacket<DateTime>(PacketType.SCGetConnectedTime); }
        }

        public DateTime DisconnectedTime
        {
            get { return _client.SendPacket<DateTime>(PacketType.SCGetDisconnectedTime); }
        }

        public bool PauseScriptOnDisconnectStatus
        {
            get
            {
                return _client.SendPacket<bool>(PacketType.SCGetPauseScriptOnDisconnectStatus);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetPauseScriptOnDisconnectStatus, value);
            }
        }

        public string GameServerIPString
        {
            get { return _client.SendPacket<string>(PacketType.SCGameServerIPString); }
        }

        public string ProxyIP
        {
            get { return _client.SendPacket<string>(PacketType.SCGetProxyIP); }
        }

        public ushort ProxyPort
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetProxyPort); }
        }

        public bool UseProxy
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetUseProxy); }
        }

        public int ChangeProfile(string name)
        {
            return _client.SendPacket<int>(PacketType.SCChangeProfile, name);
        }

        public bool CheckLag(int timeoutMs)
        {
            var result = false;
            CheckLagBegin();
            var stopTime = DateTime.Now + new TimeSpan(0, 0, 0, 0, timeoutMs);
            var checkLagEndRes = false;
            do
            {
                Thread.Sleep(20);
                checkLagEndRes = _client.SendPacket<bool>(PacketType.SCIsCheckLagEnd);
            } while (DateTime.Now <= stopTime && !checkLagEndRes);
            if (checkLagEndRes)
            {
                result = true;
            }
            CheckLagEnd();

            return result;
        }

        public void CheckLagBegin()
        {
            _client.SendPacket(PacketType.SCCheckLagBegin);
        }

        public void CheckLagEnd()
        {
            _client.SendPacket(PacketType.SCCheckLagEnd);
        }

        public void Connect()
        {
            _client.SendPacket(PacketType.SCConnect);
        }

        public void Disconnect()
        {
            _client.SendPacket(PacketType.SCDisconnect);
        }
    }
}
