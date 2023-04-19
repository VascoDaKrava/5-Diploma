using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Buildings
{
    public class BuildingView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {

        public Transform AttackTarget => transform;

    }
}