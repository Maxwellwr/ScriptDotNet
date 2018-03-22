using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IReagentService
    {
        int BMCount { get; }
        int BPCount { get; }
        int GACount { get; }
        int GSCount { get; }
        int MRCount { get; }
        int NSCount { get; }
        int SACount { get; }
        int SSCount { get; }
    }
}
