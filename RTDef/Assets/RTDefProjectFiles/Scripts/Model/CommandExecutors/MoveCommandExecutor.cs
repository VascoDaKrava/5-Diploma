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
        private NavMeshAgent _navMeshAgent;

        #endregion


        #region Properties

        public override CommandName ExecutorCommandName => CommandName.Move;

        #endregion


        #region Mono

        public override void Awake()
        {
            base.Awake();
            _navMeshAgent = GetComponent<NavMeshAgent>();
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
            _navMeshAgent.ResetPath();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var command = (IMoveCommand)baseCommand;

            _navMeshAgent.SetDestination(command.Target);
            _isOnDistance = true;
            IsCommandRunning = true;
            CommandHolder.CurrentCommand = CommandName.Move;
            CheckCommandFinishAsync();
        }

        private async void CheckCommandFinishAsync()
        {
            await Task.Run(() => { while (IsCommandRunning && _isOnDistance) { }; });
            IsCommandRunning = false;
            _isOnDistance = false;
            CommandHolder.CurrentCommand = CommandName.None;
        }

        /// <summary>
        /// Calculate agent status
        /// </summary>
        /// <returns>True if agent on distance. False if path was finished.</returns>
        private bool CalculateOnDistanceState()
        {
            if (_navMeshAgent.hasPath)
            {
                if (Vector3.Magnitude(_navMeshAgent.pathEndPosition - _navMeshAgent.transform.position) > _navMeshAgent.stoppingDistance)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}