using RTDef.Abstraction.Commands;
using RTDef.Enum;

namespace RTDef.Game.Commands
{
    public sealed class BuildCommandExecutor : CommandExecutorBase
    {
        public override CommandName ExecutorCommandName => CommandName.Build;

        public override void StopExecuteCommand()
        {
        }

        public override void TryExecuteCommand(ICommand _)
        {
        }
    }
}