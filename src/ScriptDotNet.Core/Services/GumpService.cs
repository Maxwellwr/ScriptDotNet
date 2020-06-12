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
            get { return _client.SendPacket<uint>(PacketType.SCGetGumpsCount); }
        }

        public bool IsGump
        {
            get { return GumpsCount > 0; }
        }

        public void AddGumpIgnoreByID(uint id)
        {
            _client.SendPacket(PacketType.SCAddGumpIgnoreByID, id);
        }

        public void AddGumpIgnoreBySerial(uint serial)
        {
            _client.SendPacket(PacketType.SCAddGumpIgnoreBySerial, serial);
        }

        public void ClearGumpsIgnore()
        {
            _client.SendPacket(PacketType.SCClearGumpsIgnore);
        }

        public void CloseClientGump(uint id)
        {
            _client.SendPacket(PacketType.SCCloseClientGump, id);
        }

        public void CloseSimpleGump(ushort gumpIndex)
        {
            _client.SendPacket(PacketType.SCCloseSimpleGump, gumpIndex);
        }

        public List<string> GetGumpButtonsDescription(ushort gumpIndex)
        {
            return _client.SendPacket<List<string>>(PacketType.SCGetGumpButtonsDescription, gumpIndex);
        }

        public List<string> GetGumpFullLines(ushort gumpIndex)
        {
            return _client.SendPacket<List<string>>(PacketType.SCGetGumpFullLines, gumpIndex);
        }

        public uint GetGumpID(ushort gumpIndex)
        {
            return _client.SendPacket<uint>(PacketType.SCGetGumpID, gumpIndex);
        }

        public GumpInfo GetGumpInfo(ushort gumpIndex)
        {
            return _client.SendPacket<GumpInfo>(PacketType.SCGetGumpInfo, gumpIndex);
        }

        public uint GetGumpSerial(ushort gumpIndex)
        {
            return _client.SendPacket<uint>(PacketType.SCGetGumpSerial, gumpIndex);
        }

        public List<string> GetGumpShortLines(ushort gumpIndex)
        {
            return _client.SendPacket<List<string>>(PacketType.SCGetGumpShortLines, gumpIndex);
        }

        public List<string> GetGumpTextLines(ushort gumpIndex)
        {
            return _client.SendPacket<List<string>>(PacketType.SCGetGumpTextLines, gumpIndex);
        }

        public void GumpAutoCheckBox(int checkboxId, int value)
        {
            _client.SendPacket(PacketType.SCGumpAutoCheckBox, checkboxId, value);
        }

        public void GumpAutoRadiobutton(int radiobuttonId, int value)
        {
            _client.SendPacket(PacketType.SCGumpAutoRadiobutton, radiobuttonId, value);
        }

        public void GumpAutoTextEntry(int textentryId, string value)
        {
            _client.SendPacket(PacketType.SCGumpAutoTextEntry, textentryId, value);
        }

        public bool IsGumpCanBeClosed(ushort gumpIndex)
        {
            return !_client.SendPacket<bool>(PacketType.SCGetGumpNoClose, gumpIndex);
        }

        public bool NumGumpButton(ushort gumpIndex, int value)
        {
            return _client.SendPacket<bool>(PacketType.SCNumGumpButton, gumpIndex, value);
        }

        public bool NumGumpCheckBox(ushort gumpIndex, int checkboxId, int value)
        {
            return _client.SendPacket<bool>(PacketType.SCNumGumpCheckBox, gumpIndex, checkboxId, value);
        }

        public bool NumGumpRadiobutton(ushort gumpIndex, int radiobuttonId, int value)
        {
            return _client.SendPacket<bool>(PacketType.SCNumGumpRadiobutton, gumpIndex, radiobuttonId, value);
        }

        public bool NumGumpTextEntry(ushort gumpIndex, int textentryId, string value)
        {
            return _client.SendPacket<bool>(PacketType.SCNumGumpTextEntry, gumpIndex, textentryId, value);
        }

        public void WaitGump(string value)
        {
            if (!string.IsNullOrEmpty(value))
                WaitGump(BitConverter.ToInt32(Encoding.Unicode.GetBytes(value.Trim()), 0));
        }

        public void WaitGump(int value)
        {
            _client.SendPacket(PacketType.SCWaitGumpInt, value);
        }

        public void WaitTextEntry(string value)
        {
            _client.SendPacket(PacketType.SCWaitGumpTextEntry, value);
        }
    }
}
