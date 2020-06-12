using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GumpButton
    {
        public int X;
        public int Y;
        public int ReleasedId;
        public int PressedId;
        public int Quit;
        public int PageId;
        public int ReturnValue;
        public int Page;
        public int ElemNum;
    }
}
