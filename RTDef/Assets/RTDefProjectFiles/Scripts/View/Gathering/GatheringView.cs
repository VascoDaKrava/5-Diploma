using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using UnityEngine;


namespace RTDef.Gathering
{
    public class GatheringView : SelectableObjectBase, IClickableRight, IClickableLeft, IGatheringable
    {
        public Transform GatheringTarget => transform;
    }
}