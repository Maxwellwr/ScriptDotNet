// -----------------------------------------------------------------------
// <copyright file="ContextMenu.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace ScriptDotNet
{
    public struct ContextMenu
    {
        public uint ID { get; set; }

        public byte EntriesNumber { get; set; }

        public bool NewCliloc { get; set; }

        public List<ContextMenuEntry> Entries { get; set; }
    }
}
