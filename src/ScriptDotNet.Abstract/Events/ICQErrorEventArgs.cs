// -----------------------------------------------------------------------
// <copyright file="ICQErrorEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class ICQErrorEventArgs : EventArgs
    {
        public ICQErrorEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
