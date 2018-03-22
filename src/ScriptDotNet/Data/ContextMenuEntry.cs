using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptDotNet2.Data
{
    public struct ContextMenuEntry
    {
        public ushort Tag { get; set; }
        public uint IntLocID { get; set; }
        public ushort Flags { get; set; }
        public ushort Color { get; set; }
    }
}
