// -----------------------------------------------------------------------
// <copyright file="ConnectionService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
            get { return Client.SendPacket<bool>(PacketType.SCGetARStatus); }
            set { Client.SendPacket(PacketType.SCSetARStatus, value); }
        }

        public bool Connected
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetConnectedStatus); }
        }

        public DateTime ConnectedTime
        {
            get { return Client.SendPacket<DateTime>(PacketType.SCGetConnectedTime); }
        }

        public DateTime DisconnectedTime
        {
            get { return Client.SendPacket<DateTime>(PacketType.SCGetDisconnectedTime); }
        }

        public bool PauseScriptOnDisconnectStatus
        {
            get
            {
                return Client.SendPacket<bool>(PacketType.SCGetPauseScriptOnDisconnectStatus);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetPauseScriptOnDisconnectStatus, value);
            }
        }

        public string GameServerIPString
        {
            get { return Client.SendPacket<string>(PacketType.SCGameServerIPString); }
        }

        public string ProxyIP
        {
            get { return Client.SendPacket<string>(PacketType.SCGetProxyIP); }
        }

        public ushort ProxyPort
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetProxyPort); }
        }

        public bool UseProxy
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetUseProxy); }
        }

        public int ChangeProfile(string name)
        {
            return Client.SendPacket<int>(PacketType.SCChangeProfile, name);
        }

        public int ChangeProfile(string name, string shardName, string charName)
        {
            return Client.SendPacket<int>(PacketType.SCChangeProfileEx, name, shardName, charName);
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
                checkLagEndRes = Client.SendPacket<bool>(PacketType.SCIsCheckLagEnd);
            }
            while (DateTime.Now <= stopTime && !checkLagEndRes);
            if (checkLagEndRes)
            {
                result = true;
            }

            CheckLagEnd();

            return result;
        }

        public void CheckLagBegin()
        {
            Client.SendPacket(PacketType.SCCheckLagBegin);
        }

        public void CheckLagEnd()
        {
            Client.SendPacket(PacketType.SCCheckLagEnd);
        }

        public void Connect()
        {
            Client.SendPacket(PacketType.SCConnect);
        }

        public void Disconnect()
        {
            Client.SendPacket(PacketType.SCDisconnect);
        }

        public void SetARExtParams(string shardName, string charName, bool useAtEveryConnect)
        {
            Client.SendPacket(PacketType.SCSetARExtParams, shardName, charName, useAtEveryConnect);
        }
    }
}
