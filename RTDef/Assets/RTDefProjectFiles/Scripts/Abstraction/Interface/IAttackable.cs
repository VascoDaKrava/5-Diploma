using RTDef.Units;
using System;
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
        bool isDie { get; }
        event Action<UnitView> OnDie;//Change to IAttackable
    }
}