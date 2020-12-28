// -----------------------------------------------------------------------
// <copyright file="RejectMoveItemEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class RejectMoveItemEventArgs : EventArgs
    {
        public RejectMoveItemEventArgs(RejectMoveItemReason reason)
        {
            Reason = reason;
        }

        public RejectMoveItemReason Reason { get; private set; }
    }
}
