using UnityEngine;


namespace RTDef.Abstraction
{
    public interface IInfoForPanel : IDataForPanel
    {
        Sprite Image { get; }
        string Name { get; }
        int Health { get; }
        int HealthMax { get; }
        int Attack { get; }
        int Defence { get; }
        int Range { get; }
    }
}