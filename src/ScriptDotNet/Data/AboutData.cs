using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
{
    /// <summary>
    /// About data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AboutData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public ushort[] StealthVersion;
        public ushort Build;
        public double BuildDate;
        public ushort GITRevNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] GITRevision;

        public DateTime BuildDateTime { get { return BuildDate.ToDateTime(); } }
    }
}
