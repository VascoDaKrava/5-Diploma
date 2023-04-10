using RTDef.Abstraction.Commands;
using RTDef.Enum;

namespace RTDef.Game.Commands
{
    public sealed class ProduceCommandExecutor : CommandExecutorBase
    {
        public override CommandName ExecutorCommandName => CommandName.Produce;

        public override void StopExecuteCommand()
        {
        }

        public override void TryExecuteCommand(ICommand _)
        {
        }
    }
}