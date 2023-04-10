using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Units
{
    public sealed class UnitView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {

        #region Properties

        public Transform AttackTarget => transform;

        #endregion

    }
}