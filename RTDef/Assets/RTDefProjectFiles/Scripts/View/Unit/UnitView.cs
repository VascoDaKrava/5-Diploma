using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using UnityEngine.AI;


namespace RTDef.Units
{
    public sealed class UnitView : CommandHolderBase, IClickableLeft
    {
        public NavMeshAgent Agent { get; private set; }
    }
}