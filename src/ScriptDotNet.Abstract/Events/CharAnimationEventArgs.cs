// -----------------------------------------------------------------------
// <copyright file="CharAnimationEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class CharAnimationEventArgs : ObjectEventArgs
    {
        public CharAnimationEventArgs(uint objectId, ushort action)
            : base(objectId)
        {
            Action = action;
        }

        public ushort Action { get; private set; }
    }
}
