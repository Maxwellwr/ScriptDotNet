using ScriptDotNet2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IStealthService
    {
        string CurrentScriptPath { get; }
        string ProfileName { get; }
        string ProfileShardName { get; }
        AboutData StealthInfo { get; }
        string StealthPath { get; }
        string StealthProfilePath { get; }
        uint StealthSelf { get; }
        string ShardName { get; }
        string ShardPath { get; }

        void PauseCurrentScript();
    }
}
