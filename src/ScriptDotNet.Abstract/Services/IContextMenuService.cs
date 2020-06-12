using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IContextMenuService
    {
        void ClearContextMenu();
        List<string> GetContextMenu();
        void RequestContextMenu(uint ID);
        void SetContextMenuHook(uint MenuID, byte EntryNumber);
    }
}
