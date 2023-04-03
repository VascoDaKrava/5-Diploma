using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public struct AttackCommand : IAttackCommand
    {
        public Transform AttackTarget { get; set; }
    }
}