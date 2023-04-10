using RTDef.Abstraction.Commands;
using RTDef.Enum;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class AttackCommandExecutor : CommandExecutorBase
    {
        public override CommandName ExecutorCommandName => CommandName.Attack;

        public override void StopExecuteCommand()
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