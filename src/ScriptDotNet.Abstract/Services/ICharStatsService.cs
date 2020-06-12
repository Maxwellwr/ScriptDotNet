using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface ICharStatsService
    {
        #region State
        /// <summary>
        /// Returns the char - Stealth(Hidden).
        /// If there is no connection to the UO server - returns False.
        /// </summary>
        bool Hidden { get; }

        /// <summary>
        /// Returns the char - paralysis(Paralyzed).
        /// If there is no connection to the UO server - returns False.
        /// </summary>
        bool Paralyzed { get; }

        /// <summary>
        /// Возвращает параметр чара - Отравленность (Poisoned).
        /// В случае, если отсутствует соединение с UO сервером - вернет False.
        /// </summary>
        bool Poisoned { get; }
        #endregion

        #region Stats
        /// <summary>
        /// Returns the char - number of "units" of armor(Armor).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        ushort Armor { get; }

        /// <summary>
        /// Returns the chararacter name.
        /// If there is no connection to the UO server - returns an empty string().
        /// </summary>
        string CharName { get; }

        /// <summary>
        /// Returns the character title.
        /// If there is no connection to the UO server - returns an empty string().
        /// </summary>
        string CharTitle { get; }

        /// <summary>
        /// Returns the character dead status
        /// If True - dead, if False - alive
        /// If there is no connection to the UO server - returns False.
        /// </summary>
        bool Dead { get; }

        /// <summary>
        /// Returns the character agility(DEX).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int Dex { get; }

        /// <summary>
        /// Returns the char - count the money in the pack(Gold amount).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        uint Gold { get; }

        /// <summary>
        /// Same as <see cref="Life"/>. Returns the char - healthy(HITS).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int HP { get; }

        /// <summary>
        /// Returns the player's - intelligence(INT).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int Int { get; }

        /// <summary>
        /// Same as <see cref="HP"/>. Returns the char - healthy(HITS).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int Life { get; }

        /// <summary>
        /// Returns the char - Luck(Luck).
        /// This only works from the client version Samurie Empire + on the server must be enabled advanced stats sent to the client, otherwise returns 0.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int Luck { get; }

        /// <summary>
        /// Returns the char - Man(Mana points).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int Mana { get; }

        /// <summary>
        /// Same as <see cref="MaxLife"/>. In 99% of cases as well <see cref="Str"/>. Can differ only if the admin changes the parameters specifically object(char, SPC) and puts his hands MaxHP other than Str(usually in a big way).
        /// Returns the char - the maximum number of health(Max HITS).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int MaxHP { get; }

        /// <summary>
        /// Same as <see cref="MaxHP"/>. In 99% of cases as well <see cref="Str"/>. Can differ only if the admin changes the parameters specifically object(char, SPC) and puts his hands MaxHP other than Str(usually in a big way).
        /// Returns the char - the maximum number of health(Max HITS).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int MaxLife { get; }

        /// <summary>
        /// In 99% of the same <see cref="Int"/>. Can differ only if the admin changes the parameters specifically object(char, SPC) and puts his hands MaxMana different from Int(usually in a big way).
        /// Returns the char - the maximum amount of mana(Max Mana).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int MaxMana { get; }

        /// <summary>
        /// In 99% of the same <see cref="Dex"/>. Can differ only if the admin changes the parameters specifically object(char, SPC) and puts his hands MaxStam different from Dex(usually in a big way).
        /// Returns the chara - the maximum amount of stamina(Max Stamina).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        int MaxStam { get; }

        /// <summary>
        /// Returns the char - Maximum Weight(Weight).
        /// This only works from the client version Samurie Empire + on the server must be enabled advanced stats sent to the client, otherwise returns 0.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        ushort MaxWeight { get; }

        /// <summary>
        /// Returns the char - the number of animals(Pets).
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        byte PetsCurrent { get; }

        /// <summary>
        /// Returns the character's maximum number of animals (Pets Maximum).
        /// If there is no connection with the UO server - returns 0.
        /// </summary>
        byte PetsMax { get; }

        /// <summary>
        /// Returns the character - Race (Race).
        /// Works only from client version Samuri Empire + server must be included race, otherwise return 0.
        /// Value: 0=Human, 1=Elf (on some servers, these default values can be changed or expanded)
        /// If there is no connection with the UO server - returns 0.
        /// </summary>
        byte Race { get; }

        /// <summary>
        /// Returns the character - Gender (Sex).
        /// If 0 is returned - male, if 1 is returned - female
        /// If there is no connection with the UO server - returns 0.
        /// </summary>
        byte Sex { get; }

        /// <summary>
        /// Возвращает параметр чара - стамина (Stamina).
        /// В случае, если отсутствует соединение с UO сервером - вернет 0.
        /// </summary>
        int Stam { get; }

        /// <summary>
        /// Возвращает параметр чара - сила (STR).
        /// В случае, если отсутствует соединение с UO сервером - вернет 0.
        /// </summary>
        int Str { get; }

        /// <summary>
        /// Возвращает параметр чара - Вес (Weight).
        /// В случае, если отсутствует соединение с UO сервером - вернет 0.
        /// </summary>
        ushort Weight { get; }
        #endregion


        #region Resists
        /// <summary>
        /// Returns the char - cold resistance(Cold Resist).
        /// This only works from the client version Samurie Empire + on the server must be enabled advanced stats sent to the client, otherwise returns 0.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        ushort ColdResist { get; }

        /// <summary>
        /// Returns the char - resistance to energy(Energy Resist).
        /// This only works from the client version Samurie Empire + on the server must be enabled advanced stats sent to the client, otherwise returns 0.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        ushort EnergyResist { get; }

        /// <summary>
        /// Returns the char - refractoriness(Fire Resist).
        /// This only works from the client version Samurie Empire + on the server must be enabled advanced stats sent to the client, otherwise returns 0.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        ushort FireResist { get; }

        /// <summary>
        /// Возвращает параметр чара - сопротивление яду (Poison Resist).
        /// This only works from the client version Samurie Empire + on the server must be enabled advanced stats sent to the client, otherwise returns 0.
        /// If there is no connection to the UO server - returns 0.
        /// </summary>
        ushort PoisonResist { get; }
        #endregion

        /// <summary>
        /// Возвращает параметр чара - ID чара (Char ID).
        /// В случае, если отсутствует соединение с UO сервером - вернет 0.
        /// </summary>
        uint Self { get; }
        uint SelfHandle { get; }
        Point QuestArrow { get; }

        /// <summary>
        /// Returns the number of the Map of the current character.
        /// This works on servers where there is more than one map.
        /// Default values ​​are:
        /// 0 - Felucca (Britannia)
        /// 1 - Trammel (Britannia_alt)
        /// 2 - Ilshenar
        /// 3 - Malas
        /// 4 - Tokuno
        /// More values are possible for shards with SA support.
        /// If there is no connection with the UO server - returns 0.
        /// </summary>
        byte WorldNum { get; }

        /// <summary>
        /// Returns extended info of char in KR++ version of UO.
        /// </summary>
        ExtendedInfo ExtendedInfo { get; }
        List<BuffIcon> BuffBarInfo { get; }

        ushort X { get; }
        ushort Y { get; }
        sbyte Z { get; }

        string GetAltName(uint ObjID);
        uint GetPrice(uint ObjID);
        string GetTitle(uint ObjID);
    }
}
