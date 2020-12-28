// -----------------------------------------------------------------------
// <copyright file="HtmlGump.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HtmlGump
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int TextId;
        public int Background;
        public int Scrollbar;
        public int Page;
        public int ElemNum;
    }
}
