using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScriptDotNet2
{
    public interface IDeserialized
    {
        void Deserialize(BinaryReader data);
    }
}
