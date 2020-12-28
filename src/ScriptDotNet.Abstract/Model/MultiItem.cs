// -----------------------------------------------------------------------
// <copyright file="MultiItem.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MultiItem
    {
        public uint ID { get; set; }

        public ushort X { get; set; }

        public ushort Y { get; set; }

        public sbyte Z { get; set; }

        public ushort XMin { get; set; }

        public ushort XMax { get; set; }

        public ushort YMin { get; set; }

        public ushort YMax { get; set; }

        public ushort Width { get; set; }

        public ushort Height { get; set; }
    }
}
