// -----------------------------------------------------------------------
// <copyright file="ISkillSpellService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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

        double GetSkillCap(string skillName);

        bool GetSkillId(string skillName, out int skillId);

        double GetSkillValue(string skillName);

        double GetSkillCurrentValue(string skillName);

        bool IsActiveSpellAbility(string spellName);

        void ReqVirtuesGump();

        void SetStatState(byte statNum, byte statState);

        void SkillLockState(string skillName, byte skillState);

        void ToggleFly();

        void UseOtherPaperdollScroll(uint iD);

        void UsePrimaryAbility();

        void UseSecondaryAbility();

        void UseSelfPaperdollScroll();

        bool UseSkill(string skillName);

        void UseVirtue(string virtueName);

        void UseVirtue(Virtue virtue);
    }
}
