using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IContextMenuService
    {
        void ClearContextMenu();
        List<string> GetContextMenu();
        void RequestContextMenu(uint ID);
        void SetContextMenuHook(uint MenuID, byte EntryNumber);
    }
}
