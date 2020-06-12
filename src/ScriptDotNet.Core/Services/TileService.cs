using ScriptDotNet.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptDotNet.Services
{
    public class TileService:BaseService, ITileService
    {
        public TileService(IStealthClient client)
            :base(client)
        {

        }

        public TileDataFlags ConvertIntToFlags(TileFlagsType group, uint flags)
        {
            return _client.SendPacket<TileDataFlags>(PacketType.SCConvertFlagsToFlagSet, group, flags);
        }

        public string ConvertIntToFlags(byte group, uint flags)
        {
            return _client.SendPacket<string>(PacketType.SCConvertIntegerToFlags, group, flags);
        }

        public LandTileData GetLandTileData(ushort tile)
        {
            return _client.SendPacket<LandTileData>(PacketType.SCGetLandTileData, tile);
        }

        public List<FoundTile> GetLandTilesArray(ushort xMin, ushort yMin, ushort xMax, ushort yMax, byte worldNum, ushort tileType)
        {
            return _client.SendPacket<List<FoundTile>>(PacketType.SCGetLandTilesArray, xMin, yMin, xMax, yMax, worldNum, tileType);
        }

        public List<FoundTile> GetLandTilesArrayEx(ushort Xmin, ushort Ymin, ushort Xmax, ushort Ymax, byte WorldNum, ushort[] TileTypes)
        {
            return TileTypes.SelectMany(t => GetLandTilesArray(Xmin, Ymin, Xmax, Ymax, WorldNum, t)).Distinct(new FoundTileComparer()).ToList();
        }

        public byte GetLayerCount(ushort x, ushort y, byte worldNum)
        {
            return _client.SendPacket<byte>(PacketType.SCGetLayerCount, x, y, worldNum);
        }

        public MapCell GetMapCell(ushort x, ushort y, byte worldNum)
        {
            return _client.SendPacket<MapCell>(PacketType.SCGetCell, x, y, worldNum);
        }

        public ushort GetNextStepZ(ushort CurrX, ushort CurrY, ushort DestX, ushort DestY, byte WorldNum, sbyte Z)
        {
            throw new NotImplementedException();
        }

        public StaticTileData GetStaticTileData(ushort tile)
        {
            return _client.SendPacket<StaticTileData>(PacketType.SCGetStaticTileData, tile);
        }

        public List<FoundTile> GetStaticTilesArray(ushort xMin, ushort yMin, ushort xMax, ushort yMax, byte worldNum, ushort tileType)
        {
            return _client.SendPacket<List<FoundTile>>(PacketType.SCGetStaticTilesArray, xMin, yMin, xMax, yMax, worldNum, tileType);
        }

        public List<FoundTile> GetStaticTilesArrayEx(ushort Xmin, ushort Ymin, ushort Xmax, ushort Ymax, byte WorldNum, ushort[] TileTypes)
        {
            return TileTypes.SelectMany(t => GetStaticTilesArray(Xmin, Ymin, Xmax, Ymax, WorldNum, t)).Distinct(new FoundTileComparer()).ToList();
        }

        public byte GetSurfaceZ(ushort x, ushort y, byte worldNum)
        {
            return _client.SendPacket<byte>(PacketType.SCGetSurfaceZ, x, y, worldNum);
        }

        public uint GetTileFlags(TileFlagsType group, ushort tile)
        {
            return _client.SendPacket<uint>(PacketType.SCGetTileFlags, group, tile);
        }

        public bool IsWorldCellPassable(ushort currX, ushort currY, sbyte currZ, ushort destX, ushort destY, out sbyte destZ, byte worldNum)
        {
            var res = _client.SendPacket<byte[]>(PacketType.SCIsWorldCellPassable, currX, currY, currZ, destX, destY, worldNum);

            bool ret = BitConverter.ToBoolean(res, 0);
            destZ = (sbyte)res[1];
            return ret;
        }

        public List<StaticItemRealXY> ReadStaticsXY(ushort x, ushort y, byte worldNum)
        {
            return _client.SendPacket<List<StaticItemRealXY>>(PacketType.SCReadStaticsXY, x, y, worldNum);
        }
    }
}
