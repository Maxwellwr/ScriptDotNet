using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface ITileService
    {
        TileDataFlags ConvertIntToFlags(TileFlagsType group, uint flags);
        string ConvertIntToFlags(byte group, uint flags);
        LandTileData GetLandTileData(ushort Tile);
        List<FoundTile> GetLandTilesArray(ushort Xmin, ushort Ymin, ushort Xmax, ushort Ymax, byte WorldNum, ushort TileType);
        List<FoundTile> GetLandTilesArrayEx(ushort Xmin, ushort Ymin, ushort Xmax, ushort Ymax, byte WorldNum, ushort[] TileTypes);
        byte GetLayerCount(ushort x, ushort y, byte WorldNum);
        MapCell GetMapCell(ushort X, ushort Y, byte WorldNum);
        ushort GetNextStepZ(ushort CurrX, ushort CurrY, ushort DestX, ushort DestY, byte WorldNum, sbyte Z);
        StaticTileData GetStaticTileData(ushort Tile);
        List<FoundTile> GetStaticTilesArray(ushort Xmin, ushort Ymin, ushort Xmax, ushort Ymax, byte WorldNum, ushort TileType);
        List<FoundTile> GetStaticTilesArrayEx(ushort Xmin, ushort Ymin, ushort Xmax, ushort Ymax, byte WorldNum, ushort[] TileTypes);
        byte GetSurfaceZ(ushort X, ushort Y, byte WorldNum);
        uint GetTileFlags(TileFlagsType Group, ushort Tile);
        bool IsWorldCellPassable(ushort CurrX, ushort CurrY, sbyte Z, ushort DestX, ushort DestY, out sbyte DestZ, byte WorldNum);
        List<StaticItemRealXY> ReadStaticsXY(ushort X, ushort Y, byte WorldNum);
    }
}
