using RTDef.Abstraction.Commands;
using RTDef.Enum;
using RTDef.Units;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class KillCommandExecutor : CommandExecutorBase
    {
        public override CommandName ExecutorCommandName => CommandName.Kill;

        public override void CommandFinish()
        {
            throw new System.NotImplementedException();
        }

        public override void StopExecuteCommand()
        {
            throw new System.NotImplementedException();
        }

        public override void TryExecuteCommand(ICommand _)
        {
            Debug.Log($"{this} recieve KILL");
            
            if (gameObject.TryGetComponent(out UnitView unit))
            {
                Debug.Log($"Die call on {unit}");
                unit.Die();
            }
        }
    }
}