// -----------------------------------------------------------------------
// <copyright file="MoveRejectionEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class MoveRejectionEventArgs : EventArgs
    {
        public MoveRejectionEventArgs(ushort xSource, ushort ySource, byte direction, ushort xDest, ushort yDest)
        {
            XSource = xSource;
            YSource = ySource;
            Direction = direction;
            XDest = xDest;
            YDest = yDest;
        }

        public ushort XSource { get; private set; }

        public ushort YSource { get; private set; }

        public byte Direction { get; private set; }

        public ushort XDest { get; private set; }

        public ushort YDest { get; private set; }
    }
}
