using RTDef.Abstraction.Commands;
using RTDef.Enum;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


namespace RTDef.Game.Commands
{
    public sealed class MoveCommandExecutor : CommandExecutorBase
    {

        #region Fields

        private bool _isOnDistance;

        #endregion


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

        private void Update()
        {
            if (IsCommandRunning)
            {
                _isOnDistance = CalculateOnDistanceState();
            }
        }

        #endregion


        #region Methods

        public override void StopExecuteCommand()
        {
            IsCommandRunning = false;
            NavMeshAgent.ResetPath();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var command = (IMoveCommand)baseCommand;

            NavMeshAgent.SetDestination(command.Target);
            _isOnDistance = true;
            IsCommandRunning = true;
            CheckCommandFinishAsync();
        }

        private async void CheckCommandFinishAsync()
        {
            await Task.Run(() => { while (IsCommandRunning && _isOnDistance) { }; });
            IsCommandRunning = false;
            _isOnDistance = false;
            CommandHolder.CurrentCommand = CommandName.Move;
        }

        /// <summary>
        /// Calculate agent status
        /// </summary>
        /// <returns>True if agent on distance. False if path was finished.</returns>
        private bool CalculateOnDistanceState()
        {
            if (NavMeshAgent.hasPath)
            {
                if (Vector3.Magnitude(NavMeshAgent.pathEndPosition - NavMeshAgent.transform.position) > NavMeshAgent.stoppingDistance)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}