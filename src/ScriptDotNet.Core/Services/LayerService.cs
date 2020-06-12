using ScriptDotNet.Network;
using System;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class LayerService : BaseService, ILayerService
    {
        private readonly ICharStatsService _charStatsService;
        private readonly IObjectSearchService _objectSearchService;
        private readonly IMoveItemService _moveItemService;

        public LayerService(
            IStealthClient client,
            ICharStatsService charStatsService,
            IMoveItemService moveItemService,
            IObjectSearchService objectSearchService)
            : base(client)
        {
            _charStatsService = charStatsService;
            _objectSearchService = objectSearchService;
            _moveItemService = moveItemService;
        }

        public ushort DressSpeed
        {
            get
            {
                return _client.SendPacket<ushort>(PacketType.SCGetDressSpeed);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetDressSpeed, value);
            }
        }

        public bool Disarm()
        {
            bool lh = true;
            bool rh = true;

            uint objId = ObjAtLayerEx(Layer.LHand, _charStatsService.Self);
            if (objId != 0)
                lh = _moveItemService.MoveItem(objId, 1, _objectSearchService.Backpack, 0xff, 0xff, 0);

            objId = ObjAtLayerEx(Layer.RHand, _charStatsService.Self);
            if (objId != 0)
                rh = _moveItemService.MoveItem(objId, 1, _objectSearchService.Backpack, 0xff, 0xff, 0);

            return lh && rh;
        }

        public bool DressSavedSet()
        {
            throw new NotImplementedException();
        }

        public bool Equip(Layer layer, uint objId)
        {
            if (!Enum.IsDefined(typeof(Layer), layer))
                return false;

            if (!_moveItemService.DragItem(objId, 1))
                return false;

            Thread.Sleep(20);

            return WearItem(layer, objId);
        }

        public bool EquipDressSet()
        {
            throw new NotImplementedException();
        }

        public bool Equipt(Layer layer, ushort objType)
        {
            uint obj = _objectSearchService.FindType(objType, _objectSearchService.Backpack);
            if (obj == 0 || !Enum.IsDefined(typeof(Layer), layer))
                return false;

            if (!_moveItemService.DragItem(obj, 1))
                return false;

            return WearItem(layer, obj);
        }

        public Layer GetLayer(uint objId)
        {
            return (Layer)_client.SendPacket<byte>(PacketType.SCGetLayer, objId);
        }

        public uint ObjAtLayer(Layer layer)
        {
            return ObjAtLayerEx(layer, _charStatsService.Self);
        }

        public uint ObjAtLayerEx(Layer layer, uint playerId)
        {
            if (!Enum.IsDefined(typeof(Layer), layer))
                return 0;

            return _client.SendPacket<uint>(PacketType.SCObjAtLayerEx, layer, playerId);
        }

        public void SetDress()
        {
            _client.SendPacket(PacketType.SCSetDress);
        }

        public bool Undress()
        {
            bool result = true;
            foreach (Layer layer in Enum.GetValues(typeof(Layer)))
            {
                if (ObjAtLayerEx(layer, _charStatsService.Self) > 0)
                {
                    result &= Unequip(layer);
                    Thread.Sleep(DressSpeed);
                }
            }
            return result;
        }

        public bool Unequip(Layer layer)
        {
            if (!Enum.IsDefined(typeof(Layer), layer))
                return false;
            uint objId = ObjAtLayerEx(layer, _charStatsService.Self);
            if (objId != 0)
                return _moveItemService.MoveItem(objId, 1, _objectSearchService.Backpack, 0, 0, 0);
            else
                return false;
        }

        public bool WearItem(Layer layer, uint objId)
        {
            if (_moveItemService.PickedUpItem == 0)
                return false;

            if (!Enum.IsDefined(typeof(Layer), layer))
                return false;
            if (_charStatsService.Self == 0x00)
                return false;

            _client.SendPacket(PacketType.SCWearItem, layer, objId);
            _moveItemService.PickedUpItem = 0;
            Thread.Sleep(1000);
            var objAtLayer = ObjAtLayer(layer);
            return objAtLayer == objId;
        }
    }
}
