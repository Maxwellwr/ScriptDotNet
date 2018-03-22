using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BuffIcon
    {
        public ushort Attribute_ID { get; set; }
        public DateTime TimeStart { get; set; }
        public ushort Seconds { get; set; }
        public uint ClilocID1 { get; set; }
        public uint ClilocID2 { get; set; }
    }
}
