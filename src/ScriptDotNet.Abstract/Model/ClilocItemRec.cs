// -----------------------------------------------------------------------
// <copyright file="ClilocItemRec.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public struct ClilocItemRec : IDeserialized
    {
        public uint ClilocID { get; set; }

        public List<string> Params { get; set; }

        public void Deserialize(BinaryReader data)
        {
            ClilocID = data.ReadUInt32();

            Params = new List<string>();

            var strCount = data.ReadUInt32();

            for (int i = 0; i < strCount; i++)
            {
                var len = data.ReadUInt32();
                var strb = data.ReadBytes((int)len * 2);
                Params.Add(Encoding.Unicode.GetString(strb));
            }
        }
    }
}
