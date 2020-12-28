// -----------------------------------------------------------------------
// <copyright file="DeathEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class DeathEventArgs : EventArgs
    {
        public DeathEventArgs(bool isDead)
        {
            IsDead = isDead;
        }

        public bool IsDead { get; private set; }
    }
}
