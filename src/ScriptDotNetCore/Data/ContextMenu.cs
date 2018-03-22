using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
{
    public struct ContextMenu
    {
        public uint ID { get; set; }
        public byte EntriesNumber { get; set; }
        public bool NewCliloc { get; set; }
        public List<ContextMenuEntry> Entries { get; set; }
    }
}
