namespace ScriptDotNet.Services
{
    public interface ITargetService
    {
        TargetInfo ClientTargetResponse { get; }
        bool ClientTargetResponsePresent { get; }
        uint TargetId { get; }
        bool TargetPresent { get; }
        uint LastTarget { get; }
        

        void CancelTarget();
        void CancelWaitTarget();
        bool CheckLOS(ushort xf, ushort yf, sbyte zf, ushort xt, ushort yt, sbyte zt, byte WorldNum);
        void ClientRequestObjectTarget();
        void ClientRequestTileTarget();
        void TargetToObject(uint ObjectID);
        void TargetToTile(ushort TileModel, ushort x, ushort y, sbyte z);
        void TargetToXYZ(ushort x, ushort y, sbyte z);
        bool WaitForClientTargetResponse(int MaxWaitTimeMS);
        bool WaitForTarget(int MaxWaitTimeMS);
        void WaitTargetGround(ushort ObjType);
        void WaitTargetLast();
        void WaitTargetObject(uint ObjID);
        void WaitTargetSelf();
        void WaitTargetTile(ushort Tile, ushort x, ushort y, sbyte z);
        void WaitTargetType(ushort ObjType);
        void WaitTargetXYZ(ushort x, ushort y, sbyte z);
    }
}
