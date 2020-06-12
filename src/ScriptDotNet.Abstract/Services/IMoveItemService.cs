namespace ScriptDotNet.Services
{
    public interface IMoveItemService
    {
        uint DropDelay { get; set; }
        uint PickedUpItem { get; set; }


        bool DragItem(uint ItemID, int Count);
        bool Drop(uint ItemID, int Count, int X, int Y, int Z);
        bool DropHere(uint ItemID);
        bool DropItem(uint MoveIntoID, int X, int Y, int Z);
        bool EmptyContainer(uint Container, uint DestContainer, ushort DelayMS);
        bool Grab(uint ItemID, int Count);
        bool MoveItem(uint ItemID, int Count, uint MoveIntoID, int X, int Y, int Z);
        bool MoveItems(uint Container, ushort ItemsType, ushort ItemsColor, uint MoveIntoID, int X, int Y, int Z, int DelayMS);
        bool MoveItemsEx(uint Container, ushort ItemsType, ushort ItemsColor, uint MoveIntoID, int X, int Y, int Z, int DelayMS, int MaxItems);

        void SetCatchBag(uint objectId);
        void UnsetCatchBag();
    }
}
