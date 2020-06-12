using ScriptDotNet.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class MenuService: BaseService, IMenuService
    {
        public MenuService(IStealthClient client)
            :base(client)
        {

        }

        public List<string> LastMenuItems
        {
            get
            {
                return _client.SendPacket<string>(PacketType.SCGetLastMenuItems).Split("\r\n".ToCharArray())
                    .Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }

        public bool MenuHookPresent
        {
            get { return _client.SendPacket<bool>(PacketType.SCMenuHookPresent); }
        }

        public bool MenuPresent
        {
            get { return _client.SendPacket<bool>(PacketType.SCMenuPresent); }
        }

        public void AutoMenu(string menuCaption, string elementCaption)
        {
            _client.SendPacket(PacketType.SCAutoMenu, menuCaption, elementCaption);
        }

        public void CancelMenu()
        {
            _client.SendPacket(PacketType.SCCancelMenu);
        }

        public void CloseMenu()
        {
            _client.SendPacket(PacketType.SCCloseMenu);
        }

        public List<string> GetMenuItems(string menuCaption)
        {
            return _client.SendPacket<string>(PacketType.SCGetMenuItems, menuCaption).Split("\r\n".ToCharArray())
                .Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public void WaitMenu(string menuCaption, string elementCaption)
        {
            _client.SendPacket(PacketType.SCWaitMenu, menuCaption, elementCaption);
        }


        public bool WaitForMenuPresent(int timeout)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(timeout);
            while (!MenuPresent && DateTime.Now < endTime)
                Thread.Sleep(10);

            return (DateTime.Now < endTime && MenuPresent);
        }
    }
}
