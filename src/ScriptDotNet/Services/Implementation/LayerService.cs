using Ninject;
using ScriptDotNet2.Common;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class LayerService : BaseService, ILayerService
    {
        [Inject]
        public ICharStatsService CharStat { private get; set; }
        [Inject]
        public IObjectSearchService Search { private get; set; }
        [Inject]
        public IMoveItemService MoveItem { private get; set; }

        public LayerService(StealthClient client)
            : base(client)
        {
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

            uint objId = ObjAtLayerEx(Layer.LHand, CharStat.Self);
            if (objId != 0)
                lh = MoveItem.MoveItem(objId, 1, Search.Backpack, 0xff, 0xff, 0);

            objId = ObjAtLayerEx(Layer.RHand, CharStat.Self);
            if (objId != 0)
                rh = MoveItem.MoveItem(objId, 1, Search.Backpack, 0xff, 0xff, 0);

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

            if (!MoveItem.DragItem(objId, 1))
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
            uint obj = Search.FindType(objType, Search.Backpack);
            if (obj == 0 || !Enum.IsDefined(typeof(Layer), layer))
                return false;

            if (!MoveItem.DragItem(obj, 1))
                return false;

            return WearItem(layer, obj);
        }

        public Layer GetLayer(uint objId)
        {
            return (Layer)_client.SendPacket<byte>(PacketType.SCGetLayer, objId);
        }

        public uint ObjAtLayer(Layer layer)
        {
            return ObjAtLayerEx(layer, CharStat.Self);
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
                if (ObjAtLayerEx(layer, CharStat.Self) > 0)
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
            uint objId = ObjAtLayerEx(layer, CharStat.Self);
            if (objId != 0)
                return MoveItem.MoveItem(objId, 1, Search.Backpack, 0, 0, 0);
            else
                return false;
        }

        public bool WearItem(Layer layer, uint objId)
        {
            if (MoveItem.PickedUpItem == 0)
                return false;

            if (!Enum.IsDefined(typeof(Layer), layer))
                return false;
            if (CharStat.Self == 0x00)
                return false;

            _client.SendPacket(PacketType.SCWearItem, layer, objId);
            MoveItem.PickedUpItem = 0;
            Thread.Sleep(1000);
            var objAtLayer = ObjAtLayer(layer);
            return objAtLayer == objId;
        }
    }
}
