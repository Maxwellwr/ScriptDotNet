using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Network
{
    public enum DataType : byte
    {
        parUnicodeString = 0,
        parInteger = 1,
        parBoolean = 2,
        parCardinal = 3,
        parWord = 4,
        parByte = 5,
        parByteArray = 6
    }

}
