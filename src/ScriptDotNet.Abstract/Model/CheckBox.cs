using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CheckBox
    {
        public int X;
        public int Y;
        public int ReleasedId;
        public int PressedId;
        public int Status;
        public int ReturnValue;
        public int Page;
        public int ElemNum;
    }
}
