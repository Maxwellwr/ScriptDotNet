// -----------------------------------------------------------------------
// <copyright file="ButtonTileArt.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ButtonTileArt
    {
        public int X;
        public int Y;
        public int ReleasedId;
        public int PressedId;
        public int Quit;
        public int PageId;
        public int ReturnValue;
        public int ArtId;
        public int Hue;
        public int ArtX;
        public int ArtY;
        public int ElemNum;
    }
}
