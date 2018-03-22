using ScriptDotNet2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IGlobalService
    {
        string GetGlobal(VarRegion GlobalRegion, string VarName);
        void SetGlobal(VarRegion GlobalRegion, string VarName, string VarValue);
    }
}
