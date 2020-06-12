using ScriptDotNet.Network;
using System;
using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class CharStatsService : BaseService, ICharStatsService
    {
        private readonly IGameObjectService _gameObjectService;
        private readonly IObjectSearchService _objectSearchService;
        private readonly IMoveItemService _moveItemService;

        public CharStatsService(
            IStealthClient client,
            IGameObjectService gameObjectService,
            IObjectSearchService objectSearchService,
            IMoveItemService moveItemService)
            : base(client)
        {
            _gameObjectService = gameObjectService;
            _objectSearchService = objectSearchService;
            _moveItemService = moveItemService;
        }

        public bool Hidden
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetHiddenStatus); }
        }

        public bool Paralyzed
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetParalyzedStatus); }
        }

        public bool Poisoned
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetPoisonedStatus); }
        }

        public ushort Armor
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfArmor); }
        }

        public string CharName
        {
            get { return _client.SendPacket<string>(PacketType.SCGetCharName); }
        }

        public string CharTitle
        {
            get { return _client.SendPacket<string>(PacketType.SCGetCharTitle); }
        }

        public bool Dead
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetDeadStatus); }
        }

        public int Dex
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfDex); }
        }

        public uint Gold
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetGetSelfGold); }
        }

        public int HP
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfLife); }
        }

        public int Int
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfInt); }
        }

        public int Life
        {
            get { return HP; }
        }

        public int Luck
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfLuck); }
        }

        public int Mana
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfMana); }
        }

        public int MaxHP
        {
            get { return MaxLife; }
        }

        public int MaxLife
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfMaxLife); }
        }

        public int MaxMana
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfMaxMana); }
        }

        public int MaxStam
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfMaxStam); }
        }

        public ushort MaxWeight
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfMaxWeight); }
        }

        public byte PetsCurrent
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetSelfPetsCurrent); }
        }

        public byte PetsMax
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetSelfPetsMax); }
        }

        public byte Race
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetSelfRace); }
        }

        public byte Sex
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetSelfSex); }
        }

        public int Stam
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfStam); }
        }

        public int Str
        {
            get { return _client.SendPacket<int>(PacketType.SCGetSelfStr); }
        }

        public ushort Weight
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfWeight); }
        }

        public ushort ColdResist
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfColdResist); }
        }

        public ushort EnergyResist
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfEnergyResist); }
        }

        public ushort FireResist
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfFireResist); }
        }

        public ushort PoisonResist
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetSelfPoisonResist); }
        }

        public Point QuestArrow
        {
            get { return _client.SendPacket<Point>(PacketType.SCGetQuestArrow); }
        }

        private uint _self;
        public uint Self
        {
            get
            {
                if (_self == 0)
                    _self = _client.SendPacket<uint>(PacketType.SCGetSelfID);
                return _self;
            }
        }

        public uint SelfHandle
        {
            get { throw new NotImplementedException(); }
        }

        public byte WorldNum
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetWorldNum); }
        }

        public ExtendedInfo ExtendedInfo
        {
            get { return _client.SendPacket<ExtendedInfo>(PacketType.SCGetExtInfo); }
        }

        public List<BuffIcon> BuffBarInfo
        {
            get { return _client.SendPacket<List<BuffIcon>>(PacketType.SCGetBuffBarInfo); }
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
            return _client.SendPacket<string>(PacketType.SCGetAltName, objId);
        }

        public uint GetPrice(uint objId)
        {
            return _client.SendPacket<uint>(PacketType.SCGetPrice, objId);
        }

        public string GetTitle(uint objId)
        {
            return _client.SendPacket<string>(PacketType.SCGetTitle, objId);
        }
    }
}
