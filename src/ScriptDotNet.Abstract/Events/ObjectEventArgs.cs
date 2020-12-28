// -----------------------------------------------------------------------
// <copyright file="ObjectEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class ObjectEventArgs : EventArgs
    {
        public ObjectEventArgs(uint objectId)
        {
            ObjectId = objectId;
        }

        public uint ObjectId { get; private set; }
    }
}
