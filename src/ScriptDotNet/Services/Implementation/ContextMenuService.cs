using ScriptDotNet2.Data;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class ContextMenuService: BaseService, IContextMenuService
    {
        public ContextMenuService(StealthClient client)
            :base(client)
        {

        }

        public void ClearContextMenu()
        {
            _client.SendPacket(PacketType.SCClearContextMenu);
        }

        public List<string> GetContextMenu()
        {
            return _client.SendPacket<string>(PacketType.SCGetContextMenu).Split("\r\n".ToCharArray())
                .Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public ContextMenu GetContextMenuRec()
        {
            return _client.SendPacket<ContextMenu>(PacketType.SCGetContextMenuRec);
        }

        public void RequestContextMenu(uint id)
        {
            _client.SendPacket(PacketType.SCRequestContextMenu, id);
        }

        public void SetContextMenuHook(uint menuId, byte entryNumber)
        {
            _client.SendPacket(PacketType.SCContextMenuHook, menuId, entryNumber);
        }
    }
}
