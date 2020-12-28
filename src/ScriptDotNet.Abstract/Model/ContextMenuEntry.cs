// -----------------------------------------------------------------------
// <copyright file="ContextMenuEntry.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public struct ContextMenuEntry
    {
        public ushort Tag { get; set; }

        public uint IntLocID { get; set; }

        public ushort Flags { get; set; }

        public ushort Color { get; set; }
    }
}
