using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class EasyUOService:BaseService, IEasyUOService
    {
        public EasyUOService(StealthClient client)
            :base(client)
        {

        }

        public uint EUO2ID(string EUO)
        {
            uint ret = 0;
            uint i = 1;
            foreach (var c in EUO)
            {
                ret += (c - (uint)65) * i;
                i *= 26;
            }
            return (ret - 7) ^ 0x45;
        }

        public ushort EUO2Type(string EUO)
        {
            uint a = 0;
            uint i = 1;
            foreach (var c in EUO)
            {
                a += ((c - (uint)65) * i);
                i *= 26;
            }
            a = (a - 7) ^ 0x45;
            if (a > 0xFFFF)
                return 0;

            return (ushort)a;
        }

        public string GetEasyUO(int num)
        {
            var euokey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"\Software\EasyUO", false);
            return euokey.GetValue("*" + num.ToString()).ToString();
        }

        public void SetEasyUO(int num, string regValue)
        {
            var euokey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"\Software\EasyUO", false);
            if (euokey != null)
                euokey.SetValue("*" + num.ToString(), regValue);
        }
    }
}
