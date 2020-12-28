// -----------------------------------------------------------------------
// <copyright file="IContextMenuService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IContextMenuService
    {
        void ClearContextMenu();

        List<string> GetContextMenu();

        void RequestContextMenu(uint iD);

        void SetContextMenuHook(uint menuID, byte entryNumber);
    }
}
