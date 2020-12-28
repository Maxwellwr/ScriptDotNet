// -----------------------------------------------------------------------
// <copyright file="TileService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptDotNet.Services
{
    public class TileService : BaseService, ITileService
    {
        public TileService(IStealthClient client)
            : base(client)
        {
        }

        public TileDataFlags ConvertIntToFlags(TileFlagsType group, uint flags)
        {
            return Client.SendPacket<TileDataFlags>(PacketType.SCConvertFlagsToFlagSet, group, flags);
        }

        public string ConvertIntToFlags(byte group, uint flags)
        {
            return Client.SendPacket<string>(PacketType.SCConvertIntegerToFlags, group, flags);
        }

        public LandTileData GetLandTileData(ushort tile)
        {
            return Client.SendPacket<LandTileData>(PacketType.SCGetLandTileData, tile);
        }

        public List<FoundTile> GetLandTilesArray(ushort xMin, ushort yMin, ushort xMax, ushort yMax, byte worldNum, ushort tileType)
        {
            return Client.SendPacket<List<FoundTile>>(PacketType.SCGetLandTilesArray, xMin, yMin, xMax, yMax, worldNum, tileType);
        }

        public List<FoundTile> GetLandTilesArrayEx(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte worldNum, ushort[] tileTypes)
        {
            return tileTypes.SelectMany(t => GetLandTilesArray(xmin, ymin, xmax, ymax, worldNum, t)).Distinct(new FoundTileComparer()).ToList();
        }

        public byte GetLayerCount(ushort x, ushort y, byte worldNum)
        {
            return Client.SendPacket<byte>(PacketType.SCGetLayerCount, x, y, worldNum);
        }

        public MapCell GetMapCell(ushort x, ushort y, byte worldNum)
        {
            return Client.SendPacket<MapCell>(PacketType.SCGetCell, x, y, worldNum);
        }

        public ushort GetNextStepZ(ushort currX, ushort currY, ushort destX, ushort destY, byte worldNum, sbyte z)
        {
            throw new NotImplementedException();
        }

        public StaticTileData GetStaticTileData(ushort tile)
        {
            return Client.SendPacket<StaticTileData>(PacketType.SCGetStaticTileData, tile);
        }

        public List<FoundTile> GetStaticTilesArray(ushort xMin, ushort yMin, ushort xMax, ushort yMax, byte worldNum, ushort tileType)
        {
            return Client.SendPacket<List<FoundTile>>(PacketType.SCGetStaticTilesArray, xMin, yMin, xMax, yMax, worldNum, tileType);
        }

        public List<FoundTile> GetStaticTilesArrayEx(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte worldNum, ushort[] tileTypes)
        {
            return tileTypes.SelectMany(t => GetStaticTilesArray(xmin, ymin, xmax, ymax, worldNum, t)).Distinct(new FoundTileComparer()).ToList();
        }

        public byte GetSurfaceZ(ushort x, ushort y, byte worldNum)
        {
            return Client.SendPacket<byte>(PacketType.SCGetSurfaceZ, x, y, worldNum);
        }

        public uint GetTileFlags(TileFlagsType group, ushort tile)
        {
            return Client.SendPacket<uint>(PacketType.SCGetTileFlags, group, tile);
        }

        public bool IsWorldCellPassable(ushort currX, ushort currY, sbyte currZ, ushort destX, ushort destY, out sbyte destZ, byte worldNum)
        {
            var res = Client.SendPacket<byte[]>(PacketType.SCIsWorldCellPassable, currX, currY, currZ, destX, destY, worldNum);

            bool ret = BitConverter.ToBoolean(res, 0);
            destZ = (sbyte)res[1];
            return ret;
        }

        public List<StaticItemRealXY> ReadStaticsXY(ushort x, ushort y, byte worldNum)
        {
            return Client.SendPacket<List<StaticItemRealXY>>(PacketType.SCReadStaticsXY, x, y, worldNum);
        }
    }
}
