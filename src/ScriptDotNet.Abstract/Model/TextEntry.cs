using System.Runtime.InteropServices;

namespace ScriptDotNet
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
