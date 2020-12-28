// -----------------------------------------------------------------------
// <copyright file="StaticTileData.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StaticTileData
    {
        public ulong Flags;
        public int Weight;
        public int Height;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] RadarColorRGBA;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Name;
    }
}
