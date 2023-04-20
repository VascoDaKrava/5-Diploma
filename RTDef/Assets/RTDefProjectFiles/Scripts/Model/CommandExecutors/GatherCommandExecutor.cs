using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Enum;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


namespace RTDef.Game.Commands
{
    public sealed class GatherCommandExecutor : CommandExecutorBase
    {

        #region Fields

        [SerializeField]

        private Animator _animator;
        private AudioSource _audioSource;
        private NavMeshAgent _navMeshAgent;

        private IHarvestable _target;
        private bool _isOnDistance;
        private bool _isHarvesting;

        #endregion


        #region Properties

        public override CommandName ExecutorCommandName => CommandName.Gathering;

        #endregion


        #region Mono

        public override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (IsCommandRunning)
            {
                if (_isOnDistance)
                {
                    _isOnDistance = CalculateOnDistanceState();
                }
                else
                {
                    if (_isHarvesting)
                    {
                        Harvest();
                    }
                }
            }
        }

        #endregion


        #region Methods

        public override void CommandFinish()
        {
            IsCommandRunning = false;
            CommandHolder.CurrentCommand = CommandName.None;
        }

        public override void StopExecuteCommand()
        {
            IsCommandRunning = false;
            _navMeshAgent.ResetPath();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var gatheringCommand = (IHarvestCommand)baseCommand;

            _target = gatheringCommand.Target;

            CommandHolder.CurrentCommand = CommandName.Gathering;

            MoveToTarget();
        }

        private void MoveToTarget()
        {
            _navMeshAgent.SetDestination(_target.HarvestTarget.position);
            _isHarvesting = false;
            IsCommandRunning = true;
            _isOnDistance = true;
            Debug.Log("Start move");
            CheckMoveFinishAsync();
            Debug.Log("Move to target in progress");
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

        private async void CheckMoveFinishAsync()
        {
            await Task.Run(() => { while (IsCommandRunning && _isOnDistance) { }; });
            Debug.Log("Move to target finish");
            _isOnDistance = false;
            _isHarvesting = true;
        }

        private void Harvest()
        {
            switch (_target.ResourceType)
            {
                case ResourceType.None:
                    break;

                case ResourceType.Food:
                    break;
                
                case ResourceType.Wood:
                    break;
                
                default:
                    break;
            }
        }

        #endregion

    }
}