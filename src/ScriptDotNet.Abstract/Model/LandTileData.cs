// -----------------------------------------------------------------------
// <copyright file="LandTileData.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Land Tile Data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LandTileData
    {
        public uint Flags;
        public uint Flags2;
        public ushort TextureID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Name;
    }
}
