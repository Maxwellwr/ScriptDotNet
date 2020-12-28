// -----------------------------------------------------------------------
// <copyright file="AddItemToContainerEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class AddItemToContainerEventArgs : ItemEventArgs
    {
        public AddItemToContainerEventArgs(uint itemId, uint containerId)
            : base(itemId)
        {
            ContainerId = containerId;
        }

        public uint ContainerId { get; private set; }
    }
}
