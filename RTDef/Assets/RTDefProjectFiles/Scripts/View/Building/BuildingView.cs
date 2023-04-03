using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Buildings
{
    public class BuildingView : MonoBehaviour, IClickableLeft, IClickableRight, IAttackable
    {

        public Transform AttackTarget => transform;

    }
}