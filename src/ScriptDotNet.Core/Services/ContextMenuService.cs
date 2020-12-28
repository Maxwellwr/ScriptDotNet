// -----------------------------------------------------------------------
// <copyright file="ContextMenuService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System.Collections.Generic;
using System.Linq;

namespace ScriptDotNet.Services
{
    public class ContextMenuService : BaseService, IContextMenuService
    {
        public ContextMenuService(IStealthClient client)
            : base(client)
        {
        }

        public void ClearContextMenu()
        {
            Client.SendPacket(PacketType.SCClearContextMenu);
        }

        public List<string> GetContextMenu()
        {
            return Client.SendPacket<string>(PacketType.SCGetContextMenu).Split("\r\n".ToCharArray())
                .Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public ContextMenu GetContextMenuRec()
        {
            return Client.SendPacket<ContextMenu>(PacketType.SCGetContextMenuRec);
        }

        public void RequestContextMenu(uint id)
        {
            Client.SendPacket(PacketType.SCRequestContextMenu, id);
        }

        public void SetContextMenuHook(uint menuId, byte entryNumber)
        {
            Client.SendPacket(PacketType.SCContextMenuHook, menuId, entryNumber);
        }
    }
}
