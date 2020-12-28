// -----------------------------------------------------------------------
// <copyright file="GumpService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptDotNet.Services
{
    public class GumpService : BaseService, IGumpService
    {
        public GumpService(IStealthClient client)
            : base(client)
        {
        }

        public uint GumpsCount
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetGumpsCount); }
        }

        public bool IsGump
        {
            get { return GumpsCount > 0; }
        }

        public void AddGumpIgnoreByID(uint id)
        {
            Client.SendPacket(PacketType.SCAddGumpIgnoreByID, id);
        }

        public void AddGumpIgnoreBySerial(uint serial)
        {
            Client.SendPacket(PacketType.SCAddGumpIgnoreBySerial, serial);
        }

        public void ClearGumpsIgnore()
        {
            Client.SendPacket(PacketType.SCClearGumpsIgnore);
        }

        public void CloseClientGump(uint id)
        {
            Client.SendPacket(PacketType.SCCloseClientGump, id);
        }

        public void CloseSimpleGump(ushort gumpIndex)
        {
            Client.SendPacket(PacketType.SCCloseSimpleGump, gumpIndex);
        }

        public List<string> GetGumpButtonsDescription(ushort gumpIndex)
        {
            return Client.SendPacket<List<string>>(PacketType.SCGetGumpButtonsDescription, gumpIndex);
        }

        public List<string> GetGumpFullLines(ushort gumpIndex)
        {
            return Client.SendPacket<List<string>>(PacketType.SCGetGumpFullLines, gumpIndex);
        }

        public uint GetGumpID(ushort gumpIndex)
        {
            return Client.SendPacket<uint>(PacketType.SCGetGumpID, gumpIndex);
        }

        public GumpInfo GetGumpInfo(ushort gumpIndex)
        {
            return Client.SendPacket<GumpInfo>(PacketType.SCGetGumpInfo, gumpIndex);
        }

        public uint GetGumpSerial(ushort gumpIndex)
        {
            return Client.SendPacket<uint>(PacketType.SCGetGumpSerial, gumpIndex);
        }

        public List<string> GetGumpShortLines(ushort gumpIndex)
        {
            return Client.SendPacket<List<string>>(PacketType.SCGetGumpShortLines, gumpIndex);
        }

        public List<string> GetGumpTextLines(ushort gumpIndex)
        {
            return Client.SendPacket<List<string>>(PacketType.SCGetGumpTextLines, gumpIndex);
        }

        public void GumpAutoCheckBox(int checkboxId, int value)
        {
            Client.SendPacket(PacketType.SCGumpAutoCheckBox, checkboxId, value);
        }

        public void GumpAutoRadiobutton(int radiobuttonId, int value)
        {
            Client.SendPacket(PacketType.SCGumpAutoRadiobutton, radiobuttonId, value);
        }

        public void GumpAutoTextEntry(int textentryId, string value)
        {
            Client.SendPacket(PacketType.SCGumpAutoTextEntry, textentryId, value);
        }

        public bool IsGumpCanBeClosed(ushort gumpIndex)
        {
            return !Client.SendPacket<bool>(PacketType.SCGetGumpNoClose, gumpIndex);
        }

        public bool NumGumpButton(ushort gumpIndex, int value)
        {
            return Client.SendPacket<bool>(PacketType.SCNumGumpButton, gumpIndex, value);
        }

        public bool NumGumpCheckBox(ushort gumpIndex, int checkboxId, int value)
        {
            return Client.SendPacket<bool>(PacketType.SCNumGumpCheckBox, gumpIndex, checkboxId, value);
        }

        public bool NumGumpRadiobutton(ushort gumpIndex, int radiobuttonId, int value)
        {
            return Client.SendPacket<bool>(PacketType.SCNumGumpRadiobutton, gumpIndex, radiobuttonId, value);
        }

        public bool NumGumpTextEntry(ushort gumpIndex, int textentryId, string value)
        {
            return Client.SendPacket<bool>(PacketType.SCNumGumpTextEntry, gumpIndex, textentryId, value);
        }

        public void WaitGump(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                WaitGump(BitConverter.ToInt32(Encoding.Unicode.GetBytes(value.Trim()), 0));
            }
        }

        public void WaitGump(int value)
        {
            Client.SendPacket(PacketType.SCWaitGumpInt, value);
        }

        public void WaitTextEntry(string value)
        {
            Client.SendPacket(PacketType.SCWaitGumpTextEntry, value);
        }
    }
}
