using UnityEngine;


namespace RTDef.Abstraction
{
    public interface IAttackable
    {
        Transform AttackTarget { get; }
    }
}