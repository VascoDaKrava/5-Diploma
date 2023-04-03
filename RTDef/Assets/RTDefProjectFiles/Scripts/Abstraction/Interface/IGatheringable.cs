using UnityEngine;


namespace RTDef.Abstraction
{
    public interface IGatheringable
    {
        Transform GatheringTarget { get; }
    }
}