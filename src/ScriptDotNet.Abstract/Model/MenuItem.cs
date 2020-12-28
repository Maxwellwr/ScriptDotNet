// -----------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public struct MenuItem : IDeserialized
    {
        public ushort Model;
        public ushort Color;
        public string Text;

        public void Deserialize(BinaryReader data)
        {
            Model = data.ReadUInt16();
            Color = data.ReadUInt16();
            var len = data.ReadInt32();
            Text = Encoding.Unicode.GetString(data.ReadBytes(len * 2));
        }
    }
}
