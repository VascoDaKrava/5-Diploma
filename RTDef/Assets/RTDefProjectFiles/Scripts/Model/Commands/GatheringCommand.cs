using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public struct GatheringCommand : IGatheringCommand
    {
        public Vector3 Target { get; set; }
    }
}