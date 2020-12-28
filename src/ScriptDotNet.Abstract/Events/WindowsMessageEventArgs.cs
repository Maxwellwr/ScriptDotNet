// -----------------------------------------------------------------------
// <copyright file="WindowsMessageEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class WindowsMessageEventArgs : EventArgs
    {
        public WindowsMessageEventArgs(uint lParam)
        {
            LParam = lParam;
        }

        public uint LParam { get; private set; }
    }
}
