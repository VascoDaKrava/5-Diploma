using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public interface IAttackCommand : ICommand
    {
        Vector3 Target { get; set; }
    }
}