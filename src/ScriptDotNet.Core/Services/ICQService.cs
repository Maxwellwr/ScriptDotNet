// -----------------------------------------------------------------------
// <copyright file="ICQService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class ICQService : BaseService, IICQService
    {
        public ICQService(IStealthClient client)
            : base(client)
        {
        }

        public bool ICQConnected
        {
            get { return Client.SendPacket<bool>(PacketType.SCICQ_GetConnectedStatus); }
        }

        public void ICQConnect(string uin, string password)
        {
            Client.SendPacket(PacketType.SCICQ_Connect, uin, password);
        }

        public void ICQDisconnect()
        {
            Client.SendPacket(PacketType.SCICQ_Disconnect);
        }

        public void ICQSendText(string toUin, string text)
        {
            Client.SendPacket(PacketType.SCICQ_SendText, toUin, text);
        }

        public void ICQSetStatus(byte num)
        {
            Client.SendPacket(PacketType.SCICQ_SetStatus, num);
        }

        public void ICQSetXStatus(byte num)
        {
            Client.SendPacket(PacketType.SCICQ_SetXStatus, num);
        }
    }
}
