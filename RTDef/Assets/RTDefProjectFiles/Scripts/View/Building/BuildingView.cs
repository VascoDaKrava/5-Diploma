using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Buildings
{
    public sealed class BuildingView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {

        public Transform AttackTarget => transform;

        public bool isDie => false;

        public bool GetDamage(int damage)
        {
            Debug.Log($"{this} get {damage} damage!");
            return true;
        }
    }
}