using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public interface IAttackCommand : ICommand
    {
        Transform AttackTarget { get; set; }
    }
}