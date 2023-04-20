using RTDef.Enum;
using UnityEngine;


namespace RTDef.Abstraction
{
    public interface IHarvestable
    {
        Transform HarvestTarget { get; }
        ResourceType ResourceType { get; }
    }
}