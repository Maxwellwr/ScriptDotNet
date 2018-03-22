﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet2.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TextEntry
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int Color;
        public int ReturnValue;
        public int DefaultTextId;
        public int Page;
        public int ElemNum;
    }
}
