// -----------------------------------------------------------------------
// <copyright file="IMoveItemService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IMoveItemService
    {
        uint DropDelay { get; set; }

        uint PickedUpItem { get; set; }

        bool DragItem(uint itemID, int count);

        bool Drop(uint itemID, int count, int x, int y, int z);

        bool DropHere(uint itemID);

        bool DropItem(uint moveIntoID, int x, int y, int z);

        bool EmptyContainer(uint container, uint destContainer, ushort delayMS);

        bool Grab(uint itemID, int count);

        bool MoveItem(uint itemID, int count, uint moveIntoID, int x, int y, int z);

        bool MoveItems(uint container, ushort itemsType, ushort itemsColor, uint moveIntoID, int x, int y, int z, int delayMS);

        bool MoveItemsEx(uint container, ushort itemsType, ushort itemsColor, uint moveIntoID, int x, int y, int z, int delayMS, int maxItems);

        void SetCatchBag(uint objectId);

        void UnsetCatchBag();
    }
}
