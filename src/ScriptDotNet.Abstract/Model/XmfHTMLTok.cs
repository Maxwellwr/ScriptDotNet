﻿// -----------------------------------------------------------------------
// <copyright file="XmfHTMLTok.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XmfHTMLTok : IDeserialized
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int Background;
        public int Scrollbar;
        public int Color;
        public uint ClilocId;
        public string Arguments;
        public int Page;
        public int ElemNum;

        public void Deserialize(BinaryReader br)
        {
            X = br.ReadInt32();
            Y = br.ReadInt32();
            Width = br.ReadInt32();
            Height = br.ReadInt32();
            Background = br.ReadInt32();
            Scrollbar = br.ReadInt32();
            Color = br.ReadInt32();
            ClilocId = br.ReadUInt32();

            uint paramLength = br.ReadUInt32();
            Arguments = Encoding.Unicode.GetString(br.ReadBytes((int)paramLength * sizeof(char)), 0, (int)paramLength * sizeof(char));

            Page = br.ReadInt32();
            ElemNum = br.ReadInt32();
        }
    }
}
