using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Buildings
{
    public class BuildingView : SelectableObjectBase, IClickableLeft, IClickableRight, IAttackable
    {

        public Transform AttackTarget => transform;

    }
}