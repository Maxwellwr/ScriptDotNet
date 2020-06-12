using ScriptDotNet.Network;
using System.Collections.Generic;
using System.Linq;

namespace ScriptDotNet.Services
{
    public class ContextMenuService: BaseService, IContextMenuService
    {
        public ContextMenuService(IStealthClient client)
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
