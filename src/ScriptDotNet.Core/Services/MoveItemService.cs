// -----------------------------------------------------------------------
// <copyright file="MoveItemService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Reflection;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class MoveItemService : BaseService, IMoveItemService
    {
        private readonly ICharStatsService _charStatsService;
        private readonly IGameObjectService _gameObjectService;
        private readonly IObjectSearchService _objectSearchService;

        public MoveItemService(
            IStealthClient client,
            ICharStatsService charStatsService,
            IGameObjectService gameObjectService,
            IObjectSearchService objectSearchService)
            : base(client)
        {
            _charStatsService = charStatsService;
            _gameObjectService = gameObjectService;
            _objectSearchService = objectSearchService;
        }

        public uint DropDelay
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetDropDelay); }
            set { Client.SendPacket(PacketType.SCSetDropDelay, value); }
        }

        public uint PickedUpItem
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetPickupedItem); }
            set { Client.SendPacket(PacketType.SCSetPickupedItem, value); }
        }

        public bool DropCheckCoord
        {
            get { return Client.SendPacket<bool>(PacketType.SCGetDropCheckCoord); }
            set { Client.SendPacket(PacketType.SCSetDropCheckCoord, value); }
        }

        public bool DragItem(uint itemId, int count = 0)
        {
            int rescount = count;

            if (_charStatsService.Dead)
            {
                throw new InvalidOperationException("Error: " + MethodBase.GetCurrentMethod().ToString() + " [Character is dead]");
            }

            if (PickedUpItem != 0 && _gameObjectService.IsObjectExists(PickedUpItem))
            {
                throw new InvalidOperationException("Error: " + MethodBase.GetCurrentMethod().ToString() + " [Must drop current item before dragging a new one]");
            }

            int quantity = _gameObjectService.GetQuantity(itemId);

            if (!_gameObjectService.IsObjectExists(itemId))
            {
                throw new InvalidOperationException("Error: " + MethodBase.GetCurrentMethod().ToString() + " [Object not found]");
            }

            if (count <= 0 || count > quantity)
            {
                rescount = quantity;
            }

            Client.SendPacket(PacketType.SCDragItem, itemId, rescount);

            return PickedUpItem == itemId;
        }

        public bool Drop(uint itemId, int count, int x, int y, int z)
        {
            return MoveItem(itemId, count, _objectSearchService.Ground, x, y, z);
        }

        public bool DropHere(uint itemId)
        {
            return Drop(itemId, 0, 0, 0, 0);
        }

        public bool DropItem(uint moveIntoId, int x, int y, int z)
        {
            Client.SendPacket(PacketType.SCDropItem, moveIntoId, x, y, z);
            return true;
        }

        public bool EmptyContainer(uint container, uint destContainer, ushort delayMS)
        {
            return MoveItemsEx(container, 0xFFFF, 0xFFFF, destContainer, 0xFFFF, 0xFFFF, 0, delayMS, 0);
        }

        public bool Grab(uint itemId, int count)
        {
            return MoveItem(itemId, count, _objectSearchService.Backpack, 0, 0, 0);
        }

        public bool MoveItem(uint itemId, int count, uint moveIntoId, int x, int y, int z)
        {
            if (DragItem(itemId, count))
            {
                return DropItem(moveIntoId, x, y, z);
            }

            return false;
        }

        public bool MoveItems(uint container, ushort itemsType, ushort itemsColor, uint moveIntoId, int x, int y, int z, int delayMS)
        {
            return MoveItemsEx(container, itemsType, itemsColor, moveIntoId, x, y, z, delayMS, 0);
        }

        public bool MoveItemsEx(uint container, ushort itemsType, ushort itemsColor, uint moveIntoId, int x, int y, int z, int delayMS, int maxItems)
        {
            int moveItemsCount;
            int beforeMoveCount;

            _objectSearchService.FindTypeEx(itemsType, itemsColor, container, false);

            if (_objectSearchService.FindedList.Count == 0)
            {
                return false;
            }

            if (DropDelay > delayMS)
            {
                delayMS = (int)DropDelay;
            }

            beforeMoveCount = _objectSearchService.FindedList.Count;
            if (maxItems <= 0 || maxItems > beforeMoveCount)
            {
                moveItemsCount = beforeMoveCount;
            }
            else
            {
                moveItemsCount = maxItems;
            }

            for (int i = 0; i < moveItemsCount; i++)
            {
                uint id = _objectSearchService.FindedList[i];
                MoveItem(id, 0, moveIntoId, x, y, z);
                Thread.Sleep(delayMS);
            }

            _objectSearchService.FindTypeEx(itemsType, itemsColor, container, false);
            return _objectSearchService.FindedList.Count == beforeMoveCount - moveItemsCount;
        }

        public void SetCatchBag(uint objectId)
        {
            Client.SendPacket(PacketType.SCSetCatchBag, objectId);
        }

        public void UnsetCatchBag()
        {
            Client.SendPacket(PacketType.SCUnsetCatchBag);
        }
    }
}
