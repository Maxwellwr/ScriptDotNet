// -----------------------------------------------------------------------
// <copyright file="ClientService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;

namespace ScriptDotNet.Services
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(IStealthClient client)
            : base(client)
        {
        }

        public bool ClientHide(uint id)
        {
            throw new NotImplementedException();
        }

        public void ClientPrint(string text)
        {
            Client.SendPacket(PacketType.SCClientPrint, text);
        }

        public void ClientPrintEx(uint senderId, ushort color, ushort font, string text)
        {
            Client.SendPacket(PacketType.SCClientPrintEx, senderId, color, font, text);
        }

        public void CloseClientUIWindow(UIWindowType uiWindowType, uint id)
        {
            Client.SendPacket(PacketType.SCCloseClientUIWindow, uiWindowType, id);
        }

        public void UOSay(string text)
        {
            Client.SendPacket(PacketType.SCSendTextToUO, text);
        }

        public void UOSayColor(string text, ushort color)
        {
            Client.SendPacket(PacketType.SCSendTextToUOColor, text, color);
        }
    }
}
