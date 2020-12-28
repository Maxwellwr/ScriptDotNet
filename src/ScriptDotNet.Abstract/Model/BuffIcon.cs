// -----------------------------------------------------------------------
// <copyright file="BuffIcon.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BuffIcon
    {
        public ushort Attribute_ID { get; set; }

        public DateTime TimeStart { get; set; }

        public ushort Seconds { get; set; }

        public uint ClilocID1 { get; set; }

        public uint ClilocID2 { get; set; }
    }
}
