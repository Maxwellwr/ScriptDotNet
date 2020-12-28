// -----------------------------------------------------------------------
// <copyright file="MapMessageEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class MapMessageEventArgs : ItemEventArgs
    {
        public MapMessageEventArgs(uint itemId, uint centerX, uint centerY)
            : base(itemId)
        {
            CenterX = centerX;
            CenterY = centerY;
        }

        public uint CenterX { get; private set; }

        public uint CenterY { get; private set; }
    }
}
