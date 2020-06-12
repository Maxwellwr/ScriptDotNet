using System;

namespace ScriptDotNet
{
    public class UpdateObjectStatsEventArgs : EventArgs
    {
        public UpdateObjectStatsEventArgs(int objectId, int currentLife, int maxLife, int currentMana, int maxMana, int currentStamina, int maxStamina)
        {
            ObjectId = objectId;
            CurrentLife = currentLife;
            MaxLife = maxLife;
            CurrentMana = currentMana;
            MaxMana = maxMana;
            CurrentStamina = currentStamina;
            MaxStamina = maxStamina;
        }

        public int ObjectId { get; set; }
        public int CurrentLife { get; set; }
        public int MaxLife { get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int CurrentStamina { get; set; }
        public int MaxStamina { get; set; }
    }


}
