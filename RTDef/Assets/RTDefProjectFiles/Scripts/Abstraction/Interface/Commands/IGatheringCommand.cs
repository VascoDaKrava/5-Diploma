using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public interface IGatheringCommand : ICommand
    {
        Vector3 Target { get; set; }
    }
}