// -----------------------------------------------------------------------
// <copyright file="MapCell.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Map Cell.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapCell
    {
        public ushort Tile;
        public sbyte Z;
    }
}
