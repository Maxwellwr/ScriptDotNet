// -----------------------------------------------------------------------
// <copyright file="MenuEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class MenuEventArgs : EventArgs
    {
        public MenuEventArgs(uint dialogId, ushort menuId)
        {
            DialogId = dialogId;
            MenuId = menuId;
        }

        public uint DialogId { get; private set; }

        public ushort MenuId { get; private set; }
    }
}
