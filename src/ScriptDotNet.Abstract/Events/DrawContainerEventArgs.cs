// -----------------------------------------------------------------------
// <copyright file="DrawContainerEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class DrawContainerEventArgs : EventArgs
    {
        public DrawContainerEventArgs(uint containerId, ushort modelGump)
        {
            ContainerId = containerId;
            ModelGump = modelGump;
        }

        public uint ContainerId { get; private set; }

        public ushort ModelGump { get; private set; }
    }
}
