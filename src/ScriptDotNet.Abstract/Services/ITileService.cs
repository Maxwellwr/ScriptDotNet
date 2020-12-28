// -----------------------------------------------------------------------
// <copyright file="ITileService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface ITileService
    {
        TileDataFlags ConvertIntToFlags(TileFlagsType group, uint flags);

        string ConvertIntToFlags(byte group, uint flags);

        LandTileData GetLandTileData(ushort tile);

        List<FoundTile> GetLandTilesArray(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte worldNum, ushort tileType);

        List<FoundTile> GetLandTilesArrayEx(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte worldNum, ushort[] tileTypes);

        byte GetLayerCount(ushort x, ushort y, byte worldNum);

        MapCell GetMapCell(ushort x, ushort y, byte worldNum);

        ushort GetNextStepZ(ushort currX, ushort currY, ushort destX, ushort destY, byte worldNum, sbyte z);

        StaticTileData GetStaticTileData(ushort tile);

        List<FoundTile> GetStaticTilesArray(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte worldNum, ushort tileType);

        List<FoundTile> GetStaticTilesArrayEx(ushort xmin, ushort ymin, ushort xmax, ushort ymax, byte worldNum, ushort[] tileTypes);

        byte GetSurfaceZ(ushort x, ushort y, byte worldNum);

        uint GetTileFlags(TileFlagsType group, ushort tile);

        bool IsWorldCellPassable(ushort currX, ushort currY, sbyte z, ushort destX, ushort destY, out sbyte destZ, byte worldNum);

        List<StaticItemRealXY> ReadStaticsXY(ushort x, ushort y, byte worldNum);
    }
}
