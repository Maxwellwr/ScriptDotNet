// -----------------------------------------------------------------------
// <copyright file="MenuService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IStealthClient client)
            : base(client)
        {
        }

        public List<string> LastMenuItems
        {
            get
            {
                return Client.SendPacket<string>(PacketType.SCGetLastMenuItems).Split("\r\n".ToCharArray())
                    .Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }

        public bool MenuHookPresent
        {
            get { return Client.SendPacket<bool>(PacketType.SCMenuHookPresent); }
        }

        public bool MenuPresent
        {
            get { return Client.SendPacket<bool>(PacketType.SCMenuPresent); }
        }

        public void AutoMenu(string menuCaption, string elementCaption)
        {
            Client.SendPacket(PacketType.SCAutoMenu, menuCaption, elementCaption);
        }

        public void CancelMenu()
        {
            Client.SendPacket(PacketType.SCCancelMenu);
        }

        public void CloseMenu()
        {
            Client.SendPacket(PacketType.SCCloseMenu);
        }

        public List<string> GetMenuItems(string menuCaption)
        {
            return Client.SendPacket<string>(PacketType.SCGetMenuItems, menuCaption).Split("\r\n".ToCharArray())
                .Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public List<MenuItem> GetMenuItemsEx(string menuCaption)
        {
            return Client.SendPacket<List<MenuItem>>(PacketType.SCGetMenuItemsEx, menuCaption);
        }

        public void WaitMenu(string menuCaption, string elementCaption)
        {
            Client.SendPacket(PacketType.SCWaitMenu, menuCaption, elementCaption);
        }

        public bool WaitForMenuPresent(int timeout)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(timeout);
            while (!MenuPresent && DateTime.Now < endTime)
            {
                Thread.Sleep(10);
            }

            return DateTime.Now < endTime && MenuPresent;
        }
    }
}
