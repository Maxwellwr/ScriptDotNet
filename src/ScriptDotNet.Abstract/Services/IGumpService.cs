using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IGumpService
    {
        uint GumpsCount { get; }
        bool IsGump { get; }

        void AddGumpIgnoreByID(uint id);
        void AddGumpIgnoreBySerial(uint serial);
        void ClearGumpsIgnore();
        void CloseClientGump(uint id);
        void CloseSimpleGump(ushort gumpIndex);
        List<string> GetGumpButtonsDescription(ushort gumpIndex);
        List<string> GetGumpFullLines(ushort gumpIndex);
        uint GetGumpID(ushort gumpIndex);
        GumpInfo GetGumpInfo(ushort gumpIndex);
        uint GetGumpSerial(ushort gumpIndex);
        List<string> GetGumpShortLines(ushort gumpIndex);
        List<string> GetGumpTextLines(ushort gumpIndex);
        void GumpAutoCheckBox(int checkboxId, int value);
        void GumpAutoRadiobutton(int radiobuttonId, int value);
        void GumpAutoTextEntry(int textentryId, string value);
        bool IsGumpCanBeClosed(ushort gumpIndex);
        bool NumGumpButton(ushort gumpIndex, int value);
        bool NumGumpCheckBox(ushort gumpIndex, int checkboxId, int value);
        bool NumGumpRadiobutton(ushort gumpIndex, int radiobuttonId, int value);
        bool NumGumpTextEntry(ushort gumpIndex, int textentryId, string value);
        void WaitGump(string value);
        void WaitGump(int value);
        void WaitTextEntry(string value);
    }
}
