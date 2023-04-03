using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public interface IGatheringCommand : ICommand
    {
        Transform GatheringTarget { get; set; }
    }
}