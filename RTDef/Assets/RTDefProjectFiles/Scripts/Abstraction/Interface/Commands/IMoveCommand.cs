using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public interface IMoveCommand : ICommand
    {
        Vector3 Target { get; set; }
    }
}