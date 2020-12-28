// -----------------------------------------------------------------------
// <copyright file="AddMultipleItemsInContainerEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class AddMultipleItemsInContainerEventArgs : EventArgs
    {
        public AddMultipleItemsInContainerEventArgs(uint containerId)
        {
            ContainerId = containerId;
        }

        public uint ContainerId { get; private set; }
    }
}
