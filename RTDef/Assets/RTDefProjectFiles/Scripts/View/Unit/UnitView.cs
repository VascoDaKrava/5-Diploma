using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using UnityEngine;
using UnityEngine.AI;


namespace RTDef.Units
{
    public sealed class UnitView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {
        public NavMeshAgent Agent { get; private set; }

        public Transform AttackTarget => transform;
    }
}