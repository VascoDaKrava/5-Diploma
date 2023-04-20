using UnityEngine;


namespace RTDef.Abstraction
{
    public interface IAttackable
    {
        /// <summary>
        /// We as target
        /// </summary>
        Transform AttackTarget { get; }
        bool GetDamage(int damage);
    }
}