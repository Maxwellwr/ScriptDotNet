using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CroppedText
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int Color;
        public int TextId;
        public int Page;
        public int ElemNum;
    }
}
