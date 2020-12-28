// -----------------------------------------------------------------------
// <copyright file="Buff_DebuffSystemEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class Buff_DebuffSystemEventArgs : ObjectEventArgs
    {
        public Buff_DebuffSystemEventArgs(uint objectId, ushort attributeId, bool isEnabled)
            : base(objectId)
        {
            AttributeId = attributeId;
            IsEnabled = isEnabled;
        }

        public ushort AttributeId { get; private set; }

        public bool IsEnabled { get; private set; }
    }
}
