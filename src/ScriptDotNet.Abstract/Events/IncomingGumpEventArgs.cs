// -----------------------------------------------------------------------
// <copyright file="IncomingGumpEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class IncomingGumpEventArgs : EventArgs
    {
        public IncomingGumpEventArgs(uint serial, uint gumpId, int x, int y)
        {
            Serial = serial;
            GumpId = gumpId;
            X = x;
            Y = y;
        }

        public uint Serial { get; private set; }

        public uint GumpId { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}
