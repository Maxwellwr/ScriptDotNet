// -----------------------------------------------------------------------
// <copyright file="MessangerErrorEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class MessangerErrorEventArgs : EventArgs
    {
        public MessangerErrorEventArgs(string eventMsg)
        {
            Message = eventMsg;
        }

        public string Message { get; private set; }
    }
}
