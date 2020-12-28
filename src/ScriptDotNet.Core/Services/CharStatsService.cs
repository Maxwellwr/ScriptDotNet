// -----------------------------------------------------------------------
// <copyright file="CharStatsService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class CharStatsService : BaseService, ICharStatsService
    {
        private readonly IGameObjectService _gameObjectService;
        private uint _self;

        public CharStatsService(
            IStealthClient client,
            IGameObjectService gameObjectService)
            : base(client)
        {
            _gameObjectService = gameObjectService;
        }

        public bool Hidden
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetHiddenStatus); }
        }

        public bool Paralyzed
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetParalyzedStatus); }
        }

        public bool Poisoned
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetPoisonedStatus); }
        }

        public ushort Armor
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfArmor); }
        }

        public string CharName
        {
            get { return Client.SendPacket<string>(PacketType.SCGetCharName); }
        }

        public string CharTitle
        {
            get { return Client.SendPacket<string>(PacketType.SCGetCharTitle); }
        }

        public bool Dead
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetDeadStatus); }
        }

        public int Dex
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfDex); }
        }

        public uint Gold
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetGetSelfGold); }
        }

        public int HP
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfLife); }
        }

        public int Int
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfInt); }
        }

        public int Life
        {
            get { return HP; }
        }

        public int Luck
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfLuck); }
        }

        public int Mana
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfMana); }
        }

        public int MaxHP
        {
            get { return MaxLife; }
        }

        public int MaxLife
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfMaxLife); }
        }

        public int MaxMana
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfMaxMana); }
        }

        public int MaxStam
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfMaxStam); }
        }

        public ushort MaxWeight
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfMaxWeight); }
        }

        public byte PetsCurrent
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetSelfPetsCurrent); }
        }

        public byte PetsMax
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetSelfPetsMax); }
        }

        public byte Race
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetSelfRace); }
        }

        public byte Sex
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetSelfSex); }
        }

        public int Stam
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfStam); }
        }

        public int Str
        {
            get { return Client.SendPacket<int>(PacketType.SCGetSelfStr); }
        }

        public ushort Weight
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfWeight); }
        }

        public ushort ColdResist
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfColdResist); }
        }

        public ushort EnergyResist
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfEnergyResist); }
        }

        public ushort FireResist
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfFireResist); }
        }

        public ushort PoisonResist
        {
            get { return Client.SendPacket<ushort>(PacketType.SCGetSelfPoisonResist); }
        }

        public Point QuestArrow
        {
            get { return Client.SendPacket<Point>(PacketType.SCGetQuestArrow); }
        }

        public uint Self
        {
            get
            {
                if (_self == 0)
                {
                    _self = Client.SendPacket<uint>(PacketType.SCGetSelfID);
                }

                return _self;
            }
        }

        public uint SelfHandle
        {
            get { throw new NotImplementedException(); }
        }

        public byte WorldNum
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetWorldNum); }
        }

        public ExtendedInfo ExtendedInfo
        {
            get { return Client.SendPacket<ExtendedInfo>(PacketType.SCGetExtInfo); }
        }

        public List<BuffIcon> BuffBarInfo
        {
            get { return Client.SendPacket<List<BuffIcon>>(PacketType.SCGetBuffBarInfo); }
        }

        public ushort X
        {
            get { return _gameObjectService.GetX(Self); }
        }

        public ushort Y
        {
            get { return _gameObjectService.GetY(Self); }
        }

        public sbyte Z
        {
            get { return _gameObjectService.GetZ(Self); }
        }

        public string GetAltName(uint objId)
        {
            return Client.SendPacket<string>(PacketType.SCGetAltName, objId);
        }

        public uint GetPrice(uint objId)
        {
            return Client.SendPacket<uint>(PacketType.SCGetPrice, objId);
        }

        public string GetTitle(uint objId)
        {
            return Client.SendPacket<string>(PacketType.SCGetTitle, objId);
        }
    }
}
