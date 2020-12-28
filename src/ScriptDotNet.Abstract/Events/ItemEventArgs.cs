// -----------------------------------------------------------------------
// <copyright file="ItemEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class ItemEventArgs : EventArgs
    {
        public ItemEventArgs(uint itemId)
        {
            ItemId = itemId;
        }

        public uint ItemId { get; private set; }
    }
}
