using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public struct GatheringCommand : IGatheringCommand
    {
        public Transform GatheringTarget { get; set; }
    }
}