// -----------------------------------------------------------------------
// <copyright file="UpdateObjectStatsEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class UpdateObjectStatsEventArgs : EventArgs
    {
        public UpdateObjectStatsEventArgs(uint objectId, uint currentLife, uint maxLife, uint currentMana, uint maxMana, uint currentStamina, uint maxStamina)
        {
            ObjectId = objectId;
            CurrentLife = currentLife;
            MaxLife = maxLife;
            CurrentMana = currentMana;
            MaxMana = maxMana;
            CurrentStamina = currentStamina;
            MaxStamina = maxStamina;
        }

        public uint ObjectId { get; set; }

        public uint CurrentLife { get; set; }

        public uint MaxLife { get; set; }

        public uint CurrentMana { get; set; }

        public uint MaxMana { get; set; }

        public uint CurrentStamina { get; set; }

        public uint MaxStamina { get; set; }
    }
}
