// -----------------------------------------------------------------------
// <copyright file="AllowRefuseAttackEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class AllowRefuseAttackEventArgs : EventArgs
    {
        public AllowRefuseAttackEventArgs(uint targetId, bool isAttackOk)
        {
            TargetId = targetId;
            IsAttackOK = isAttackOk;
        }

        public uint TargetId { get; private set; }

        public bool IsAttackOK { get; private set; }
    }
}
