using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ItemProperty
    {
        public uint Prop;
        public int ElemNum;
    }
}
