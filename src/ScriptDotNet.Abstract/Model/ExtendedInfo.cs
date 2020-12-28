// -----------------------------------------------------------------------
// <copyright file="ExtendedInfo.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Extended Info.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ExtendedInfo
    {
        public ushort MaxWeight;
        public byte Race;
        public ushort StatCap;
        public byte PetsCurrent;
        public byte PetsMax;
        public ushort FireResist;
        public ushort ColdResist;
        public ushort PoisonResist;
        public ushort EnergyResist;
        public short Luck;
        public ushort DamageMin;
        public ushort DamageMax;
        public uint TithingPoints;
        public ushort HitChanceIncr;
        public ushort SwingSpeedIncr;
        public ushort DamageChanceIncr;
        public ushort LowerReagentCost;
        public ushort HPRegen;
        public ushort StamRegen;
        public ushort ManaRegen;
        public ushort ReflectPhysDamage;
        public ushort EnhancePotions;
        public ushort DefenseChanceIncr;
        public ushort SpellDamageIncr;
        public ushort FasterCastRecovery;
        public ushort FasterCasting;
        public ushort LowerManaCost;
        public ushort StrengthIncr;
        public ushort DextIncr;
        public ushort IntIncr;
        public ushort HPIncr;
        public ushort StamIncr;
        public ushort ManaIncr;
        public ushort MaxHPIncr;
        public ushort MaxStamIncr;
        public ushort MaxManaIncrease;
    }
}
