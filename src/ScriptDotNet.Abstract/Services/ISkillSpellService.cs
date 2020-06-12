using System;

namespace ScriptDotNet.Services
{
    public interface ISkillSpellService
    {
        string ActiveAbility { get; }
        uint LastStatus { get; }


        bool Cast(string spellName);
        bool Cast(Spell spell);
        bool CastSpellToObj(string spellName, uint objId);
        bool CastSpellToObj(Spell spell, uint objId);
        Double GetSkillCap(string SkillName);
        bool GetSkillId(string skillName, out int skillId);
        double GetSkillValue(string skillName);
        double GetSkillCurrentValue(string skillName);
        bool IsActiveSpellAbility(string SpellName);
        void ReqVirtuesGump();
        void SetStatState(byte statNum, byte statState);
        void SkillLockState(string SkillName, byte skillState);
        void ToggleFly();
        void UseOtherPaperdollScroll(uint ID);
        void UsePrimaryAbility();
        void UseSecondaryAbility();
        void UseSelfPaperdollScroll();
        bool UseSkill(string skillName);
        void UseVirtue(string virtueName);
        void UseVirtue(Virtue virtue);
    }
}
