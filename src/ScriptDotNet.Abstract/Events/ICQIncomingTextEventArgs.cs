// -----------------------------------------------------------------------
// <copyright file="ICQIncomingTextEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class ICQIncomingTextEventArgs : EventArgs
    {
        public ICQIncomingTextEventArgs(uint uin, string text)
        {
            UIN = uin;
            Text = text;
        }

        public uint UIN { get; private set; }

        public string Text { get; private set; }
    }
}
