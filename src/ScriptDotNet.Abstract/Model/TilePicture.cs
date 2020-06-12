using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TilePicture
    {
        public int X;
        public int Y;
        public int Id;
        public int Color;
        public int Page;
        public int ElemNum;
    }
}
