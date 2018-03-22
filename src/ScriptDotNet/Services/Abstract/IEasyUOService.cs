using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IEasyUOService
    {
        uint EUO2ID(string EUO);
        ushort EUO2Type(string EUO);
        string GetEasyUO(int num);
        void SetEasyUO(int num, string Regvalue);
    }
}
