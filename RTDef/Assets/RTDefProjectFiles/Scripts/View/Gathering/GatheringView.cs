using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using RTDef.Enum;
using UnityEngine;


namespace RTDef.Gathering
{
    public class GatheringView : SelectableObjectBase, IClickableRight, IClickableLeft, IHarvestable
    {
        public Transform HarvestTarget => transform;

        [field: SerializeField] public ResourceType ResourceType { get; private set; }
    }
}