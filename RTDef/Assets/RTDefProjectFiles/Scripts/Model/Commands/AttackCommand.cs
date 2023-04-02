using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public struct AttackCommand : IAttackCommand
    {
        public Vector3 Target { get; set; }
    }
}