using Ninject;
using ScriptDotNet2.Common;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class ReagentService: BaseService, IReagentService
    {
        [Inject]
        public IObjectSearchService Search { private get; set; }

        public ReagentService(StealthClient client)
            :base(client)
        {
        }

        public int BMCount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.BM, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int BPCount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.BP, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int GACount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.GA, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int GSCount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.GS, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int MRCount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.MR, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int NSCount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.NS, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int SACount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.SA, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }

        public int SSCount
        {
            get
            {
                Search.FindTypeEx((ushort)Reagents.SS, 0x0000, Search.Backpack, true);
                return Search.FindFullQuantity;
            }
        }
    }
}
