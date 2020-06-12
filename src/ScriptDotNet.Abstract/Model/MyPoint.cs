using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// My Point
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MyPoint
    {

        public ushort X;
        public ushort Y;
        public sbyte Z;
    }
}
