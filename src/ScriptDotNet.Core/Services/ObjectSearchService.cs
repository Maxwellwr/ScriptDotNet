using ScriptDotNet.Network;
using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class ObjectSearchService: BaseService, IObjectSearchService
    {
        public ObjectSearchService(IStealthClient client)
            :base(client)
        {

        }

        public uint Backpack
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetBackpackID); }
        }

        public int FindCount
        {
            get { return _client.SendPacket<int>(PacketType.SCGetFindCount); }
        }

        public uint FindDistance
        {
            get
            {
                return _client.SendPacket<uint>(PacketType.SCGetFindDistance);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetFindDistance, value);
            }
        }

        public List<uint> FindedList
        {
            get { return _client.SendPacket<List<uint>>(PacketType.SCGetFindedList); }
        }

        public int FindFullQuantity
        {
            get { return _client.SendPacket<int>(PacketType.SCGetFindFullQuantity); }
        }

        public bool FindInNulPoint
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetFindInNulPoint); }
            set { _client.SendPacket(PacketType.SCSetFindInNulPoint, value); }
        }

        public uint FindItem
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetFindItem); }
        }

        public int FindQuantity
        {
            get { return _client.SendPacket<int>(PacketType.SCGetFindQuantity); }
        }

        public int FindVertical
        {
            get
            {
                return _client.SendPacket<int>(PacketType.SCGetFindVertical);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetFindVertical, value);
            }
        }

        public uint Ground
        {
            get { return 0x00; }
        }

        public List<uint> IgnoreList
        {
            get { return _client.SendPacket<List<uint>>(PacketType.SCGetIgnoreList); }
        }

        public uint LastContainer
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLastContainer); }
        }

        public uint LastObject
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLastObject); }
        }

        public int Count(ushort objType)
        {
            FindType(objType, Backpack);
            return FindFullQuantity;
        }

        public int CountEx(ushort objType, ushort color, uint container)
        {
            FindTypeEx(objType, color, container, false);
            return FindFullQuantity;
        }

        public int CountGround(ushort objType)
        {
            FindType(objType, Ground);
            return FindFullQuantity;
        }

        public uint FindAtCoord(ushort x, ushort y)
        {
            return _client.SendPacket<uint>(PacketType.SCFindAtCoord, x, y);
        }

        public uint FindNotoriety(ushort objType, byte notoriety)
        {
            return _client.SendPacket<uint>(PacketType.SCFindNotoriety, objType, notoriety);
        }

        public uint FindType(ushort objType, uint container)
        {
            return FindTypeEx(objType, 0xFFFF, container, false);
        }

        public uint FindTypeEx(ushort objType, ushort color, uint container, bool inSub)
        {
            return _client.SendPacket<uint>(PacketType.SCFindTypeEx, objType, color, container, inSub);
        }

        public uint FindTypesArrayEx(ushort[] objTypes, ushort[] colors, uint[] containers, bool inSub)
        {
            return _client.SendPacket<uint>(PacketType.SCFindTypesArrayEx, objTypes, colors, containers, inSub);
        }

        public List<MultiItem> GetMultis()
        {
            return _client.SendPacket<List<MultiItem>>(PacketType.SCGetMultis);
        }

        public void Ignore(uint objId)
        {
            _client.SendPacket(PacketType.SCIgnore, objId);
        }

        public void IgnoreOff(uint objId)
        {
            _client.SendPacket(PacketType.SCIgnoreOff, objId);
        }

        public void IgnoreReset()
        {
            _client.SendPacket(PacketType.SCIgnoreReset);
        }
    }
}
