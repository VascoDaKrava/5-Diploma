using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Units
{
    public class UnitView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {

        #region Properties

        public Transform AttackTarget => transform;

        public bool GetDamage(int damage)
        {
            Debug.Log($"{this} get {damage} damage!");
            return true;
        }

        #endregion

    }
}