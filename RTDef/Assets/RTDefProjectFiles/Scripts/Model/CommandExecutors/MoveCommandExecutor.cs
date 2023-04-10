using RTDef.Abstraction.Commands;
using RTDef.Enum;
using UnityEngine.AI;


namespace RTDef.Game.Commands
{
    public sealed class MoveCommandExecutor : CommandExecutorBase
    {

        #region Properties

        private NavMeshAgent NavMeshAgent { get; set; }

        public override CommandName ExecutorCommandName => CommandName.Move;

        #endregion


        #region Mono

        public override void Awake()
        {
            base.Awake();
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        #endregion


        #region Methods

        public override void StopExecuteCommand()
        {
            NavMeshAgent.ResetPath();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var command = (IMoveCommand)baseCommand;

            NavMeshAgent.SetDestination(command.Target);
            CommandHolder.CurrentCommand = CommandName.Move;
        }

        #endregion

    }
}