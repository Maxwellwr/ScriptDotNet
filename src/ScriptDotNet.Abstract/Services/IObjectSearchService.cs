using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IObjectSearchService
    {
        /// <summary>
        /// Returns the char - ID backpack(Backpack ID).
        /// If there is no connection to the UO server - returns 0.
        /// Often used, for example, in the search, index recipient to drag things on and so forth.
        /// </summary>
        uint Backpack { get; }


        int FindCount { get; }
        uint FindDistance { get; set; }
        List<uint> FindedList { get; }
        int FindFullQuantity { get; }
        bool FindInNulPoint { get; set; }
        uint FindItem { get; }
        int FindQuantity { get; }
        int FindVertical { get; set; }       
        
        /// <summary>
        /// A pointer to the ground. Often used, for example, in the search.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        uint Ground { get; }
        List<uint> IgnoreList { get; }
        uint LastContainer { get; }
        uint LastObject { get; }

        int Count(ushort ObjType);
        int CountEx(ushort ObjType, ushort Color, uint Container);
        int CountGround(ushort ObjType);
        uint FindAtCoord(ushort x, ushort y);
        uint FindNotoriety(ushort objType, byte notoriety);
        uint FindType(ushort objType, uint container);
        uint FindTypeEx(ushort objType, ushort color, uint container, bool inSub);
        uint FindTypesArrayEx(ushort[] objTypes, ushort[] colors, uint[] containers, bool inSub);
        List<MultiItem> GetMultis();
        void Ignore(uint objId);
        void IgnoreOff(uint objId);
        void IgnoreReset();
    }
}
