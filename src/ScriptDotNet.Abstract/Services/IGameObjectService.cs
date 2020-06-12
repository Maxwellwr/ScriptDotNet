using System.Collections.Generic;
using System.Drawing;

namespace ScriptDotNet.Services
{
    public interface IGameObjectService
    {
        void ClickOnObject(uint objId);
        ushort GetColor(uint objId);
        string GetCliloc(uint objId);
        string GetClilocByID(uint clilocId);
        int GetDex(uint objId);
        byte GetDirection(uint objId);
        int GetDistance(uint objId);
        int GetHP(uint objId);
        int GetInt(uint objId);
        int GetMana(uint objId);
        int GetMaxHP(uint objId);
        int GetMaxMana(uint objId);
        int GetMaxStam(uint objId);
        string GetName(uint objId);
        byte GetNotoriety(uint objId);
        uint GetParent(uint objId);
        int GetQuantity(uint objId);
        int GetStam(uint objId);
        Bitmap GetStaticArt(uint id, ushort hue);
        int GetStr(uint objId);
        string GetTooltip(uint objId);

        /// <summary>
        /// This function will return the tooltip of an item with the records that composes it.
        /// </summary>
        /// <example>
        /// IGameObjectService _gameObject;
        /// IObjectSearchService _objectSearch;
        /// IJournalService _journal;
        /// var aa := _gameObject.GetToolTipRec(_objectSearch.Backpack);
        /// _journal.AddToSystemJournal("Total lines in Toolptip: {0}", aa.Count));
        /// if (aa.count > 0)
        /// {
        ///     for (int i = 0, i < aa.Count; if++)
        ///     {
        ///         _journal.AddToSystemJournal("Line {0}:", i);
        ///         var bb = aa.Items[i]; 
        ///         _journal.AddToSystemJournal("Cliloc: ${0:X8}",bb.ClilocID);
        ///         _journal.AddToSystemJournal("Cliloc text: {0}", _gameObject.GetClilocByID(bb.ClilocID));
        ///         for (int k = 0, k < bb.Params.Length; k++)
        ///             AddToSystemJournal("Param-{0}: {1}" ,k,bb.Params[k]);
        ///     }
        /// }
        /// </example>
        /// <param name="objId">Item id</param>
        /// <returns>List of tooltip records</returns>
        List<ClilocItemRec> GetTooltipRec(uint objId);
        ushort GetType(uint objId);
        ushort GetX(uint objId);
        ushort GetY(uint objId);
        sbyte GetZ(uint objId);
        bool IsContainer(uint objId);
        bool IsDead(uint objId);
        bool IsFemale(uint objId);
        bool IsHidden(uint objId);
        bool IsMovable(uint objId);
        bool IsNPC(uint objId);
        bool IsObjectExists(uint objId);
        bool IsParalyzed(uint objId);
        bool IsPoisoned(uint objId);
        bool IsRunning(uint objId);
        bool IsWarMode(uint objId);
        bool IsYellowHits(uint objId);
        bool MobileCanBeRenamed(uint mobId);
        void RenameMobile(uint mobId, string newName);
        uint UseFromGround(ushort ObjType, ushort Color);
        void UseObject(uint ObjectID);
        uint UseType(ushort ObjType, ushort Color);
    }
}
