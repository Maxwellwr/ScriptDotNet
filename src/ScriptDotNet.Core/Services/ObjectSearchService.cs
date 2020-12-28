// -----------------------------------------------------------------------
// <copyright file="ObjectSearchService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class ObjectSearchService : BaseService, IObjectSearchService
    {
        public ObjectSearchService(IStealthClient client)
            : base(client)
        {
        }

        public uint Backpack
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetBackpackID); }
        }

        public int FindCount
        {
            get { return Client.SendPacket<int>(PacketType.SCGetFindCount); }
        }

        public uint FindDistance
        {
            get
            {
                return Client.SendPacket<uint>(PacketType.SCGetFindDistance);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetFindDistance, value);
            }
        }

        public List<uint> FindedList
        {
            get { return Client.SendPacket<List<uint>>(PacketType.SCGetFindedList); }
        }

        public int FindFullQuantity
        {
            get { return Client.SendPacket<int>(PacketType.SCGetFindFullQuantity); }
        }

        public bool FindInNulPoint
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetFindInNulPoint); }
            set { Client.SendPacket(PacketType.SCSetFindInNulPoint, value); }
        }

        public uint FindItem
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetFindItem); }
        }

        public int FindQuantity
        {
            get { return Client.SendPacket<int>(PacketType.SCGetFindQuantity); }
        }

        public int FindVertical
        {
            get
            {
                return Client.SendPacket<int>(PacketType.SCGetFindVertical);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetFindVertical, value);
            }
        }

        public uint Ground
        {
            get { return 0x00; }
        }

        public List<uint> IgnoreList
        {
            get { return Client.SendPacket<List<uint>>(PacketType.SCGetIgnoreList); }
        }

        public uint LastContainer
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetLastContainer); }
        }

        public uint LastObject
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetLastObject); }
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
            return Client.SendPacket<uint>(PacketType.SCFindAtCoord, x, y);
        }

        public uint FindNotoriety(ushort objType, byte notoriety)
        {
            return Client.SendPacket<uint>(PacketType.SCFindNotoriety, objType, notoriety);
        }

        public uint FindType(ushort objType, uint container)
        {
            return FindTypeEx(objType, 0xFFFF, container, false);
        }

        public uint FindTypeEx(ushort objType, ushort color, uint container, bool inSub)
        {
            return Client.SendPacket<uint>(PacketType.SCFindTypeEx, objType, color, container, inSub);
        }

        public uint FindTypesArrayEx(ushort[] objTypes, ushort[] colors, uint[] containers, bool inSub)
        {
            return Client.SendPacket<uint>(PacketType.SCFindTypesArrayEx, objTypes, colors, containers, inSub);
        }

        public List<MultiItem> GetMultis()
        {
            return Client.SendPacket<List<MultiItem>>(PacketType.SCGetMultis);
        }

        public void Ignore(uint objId)
        {
            Client.SendPacket(PacketType.SCIgnore, objId);
        }

        public void IgnoreOff(uint objId)
        {
            Client.SendPacket(PacketType.SCIgnoreOff, objId);
        }

        public void IgnoreReset()
        {
            Client.SendPacket(PacketType.SCIgnoreReset);
        }
    }
}
