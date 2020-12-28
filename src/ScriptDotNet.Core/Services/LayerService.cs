﻿// -----------------------------------------------------------------------
// <copyright file="LayerService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Collections.Generic;
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
                return Client.SendPacket<ushort>(PacketType.SCGetDressSpeed);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetDressSpeed, value);
            }
        }

        public bool Disarm()
        {
            bool lh = true;
            bool rh = true;

            uint objId = ObjAtLayerEx(Layer.LHand, _charStatsService.Self);
            if (objId != 0)
            {
                lh = _moveItemService.MoveItem(objId, 1, _objectSearchService.Backpack, 0xff, 0xff, 0);
            }

            objId = ObjAtLayerEx(Layer.RHand, _charStatsService.Self);
            if (objId != 0)
            {
                rh = _moveItemService.MoveItem(objId, 1, _objectSearchService.Backpack, 0xff, 0xff, 0);
            }

            return lh && rh;
        }

        public bool DressSavedSet()
        {
            throw new NotImplementedException();
        }

        public bool Equip(Layer layer, uint objId)
        {
            if (!Enum.IsDefined(typeof(Layer), layer))
            {
                return false;
            }

            if (!_moveItemService.DragItem(objId, 1))
            {
                return false;
            }

            Thread.Sleep(20);

            return WearItem(layer, objId);
        }

        public bool EquipDressSet()
        {
            bool result = true;
            var clientVersion = Client.SendPacket<int>(PacketType.SCGetClientVersionInt);
            if (clientVersion < 7007400)
            {
                var delay = DressSpeed;
                var data = Client.SendPacket<List<LayerObject>>(PacketType.SCGetDressSet);
                foreach (var item in data)
                {
                    result &= Equip(item.Layer, item.ItemId);
                    Thread.Sleep(delay * 1000);
                }
            }
            else
            {
                Client.SendPacket(PacketType.SCEquipItemsSetMacro);
            }

            return result;
        }

        public bool Equipt(Layer layer, ushort objType)
        {
            uint obj = _objectSearchService.FindType(objType, _objectSearchService.Backpack);
            if (obj == 0 || !Enum.IsDefined(typeof(Layer), layer))
            {
                return false;
            }

            if (!_moveItemService.DragItem(obj, 1))
            {
                return false;
            }

            return WearItem(layer, obj);
        }

        public Layer GetLayer(uint objId)
        {
            return (Layer)Client.SendPacket<byte>(PacketType.SCGetLayer, objId);
        }

        public uint ObjAtLayer(Layer layer)
        {
            return ObjAtLayerEx(layer, _charStatsService.Self);
        }

        public uint ObjAtLayerEx(Layer layer, uint playerId)
        {
            if (!Enum.IsDefined(typeof(Layer), layer))
            {
                return 0;
            }

            return Client.SendPacket<uint>(PacketType.SCObjAtLayerEx, layer, playerId);
        }

        public void SetDress()
        {
            Client.SendPacket(PacketType.SCSetDress);
        }

        public bool Undress()
        {
            bool result = true;
            var clientVersion = Client.SendPacket<int>(PacketType.SCGetClientVersionInt);
            if (clientVersion < 7007400)
            {
                foreach (Layer layer in Enum.GetValues(typeof(Layer)))
                {
                    if (ObjAtLayerEx(layer, _charStatsService.Self) > 0)
                    {
                        result &= Unequip(layer);
                        Thread.Sleep(DressSpeed * 1000);
                    }
                }
            }
            else
            {
                Client.SendPacket(PacketType.SCUnequipItemsSetMacro);
            }

            return result;
        }

        public bool Unequip(Layer layer)
        {
            if (!Enum.IsDefined(typeof(Layer), layer))
            {
                return false;
            }

            uint objId = ObjAtLayerEx(layer, _charStatsService.Self);
            if (objId != 0)
            {
                return _moveItemService.MoveItem(objId, 1, _objectSearchService.Backpack, 0, 0, 0);
            }
            else
            {
                return false;
            }
        }

        public bool WearItem(Layer layer, uint objId)
        {
            if (_moveItemService.PickedUpItem == 0)
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(Layer), layer))
            {
                return false;
            }

            if (_charStatsService.Self == 0x00)
            {
                return false;
            }

            Client.SendPacket(PacketType.SCWearItem, layer, objId);
            _moveItemService.PickedUpItem = 0;
            Thread.Sleep(1000);
            var objAtLayer = ObjAtLayer(layer);
            return objAtLayer == objId;
        }
    }
}
