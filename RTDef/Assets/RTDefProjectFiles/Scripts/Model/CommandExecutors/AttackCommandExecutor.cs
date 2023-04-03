using RTDef.Abstraction.Commands;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class AttackCommandExecutor : CommandExecutorBase
    {

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var command = (IAttackCommand)baseCommand;

            Debug.Log($"Attack {command.AttackTarget}");
        }
    }
}