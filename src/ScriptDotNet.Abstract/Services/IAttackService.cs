namespace ScriptDotNet.Services
{
    public interface IAttackService
    {
        /// <summary>
        /// Last attacked object
        /// </summary>
        uint LastAttack { get; }

        /// <summary>
        /// Returns the state of combat mode (War).
        /// </summary>
        bool WarMode { get; set; }

        /// <summary>
        /// Return the ID of the currently attacked target.
        /// If your character is not in war mode or it is not connected it will return 0.
        /// <example>
        /// IAttackService _attack;
        /// uint _enemy;
        /// if (_attack.WarTargetID <> _enemy) then
        ///     _attack.Attack(_enemy);
        /// </example>
        /// </summary>
        uint WarTargetID { get; }

        /// <summary>
        /// Throw an attack on the object ObjdID.
        /// If you are not in War mode, the client can install it before the attack.
        /// </summary>
        /// <example>
        /// IAttackService _attack;
        /// uint _enemy;
        /// if (_attack.WarTargetID <> _enemy) then
        ///     _attack.Attack(_enemy);
        /// </example>
        /// <param name="attackedId">Object for attack</param>
        void Attack(uint attackedId); 
    }
}
