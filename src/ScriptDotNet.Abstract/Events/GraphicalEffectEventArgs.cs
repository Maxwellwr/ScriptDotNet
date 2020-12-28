// -----------------------------------------------------------------------
// <copyright file="GraphicalEffectEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class GraphicalEffectEventArgs : EventArgs
    {
        public GraphicalEffectEventArgs(uint srcId, ushort srcX, ushort srcY, short srcZ, uint dstId, ushort dstX, ushort dstY, short dstZ, byte type, ushort itemId, byte fixedDir)
        {
            SrcId = srcId;
            SrcX = srcX;
            SrcY = srcY;
            SrcZ = srcZ;
            DstId = dstId;
            DstX = dstX;
            DstY = dstY;
            DstZ = dstZ;
            Type = type;
            ItemId = itemId;
            FixedDir = fixedDir;
        }

        public uint SrcId { get; private set; }

        public ushort SrcX { get; private set; }

        public ushort SrcY { get; private set; }

        public short SrcZ { get; private set; }

        public uint DstId { get; private set; }

        public ushort DstX { get; private set; }

        public ushort DstY { get; private set; }

        public short DstZ { get; private set; }

        public byte Type { get; private set; }

        public ushort ItemId { get; private set; }

        public byte FixedDir { get; private set; }
    }
}
