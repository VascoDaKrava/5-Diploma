using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Data.Audio;
using RTDef.Enum;
using RTDef.Game.Animations;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


namespace RTDef.Game.Commands
{
    public sealed class HarvestCommandExecutor : CommandExecutorBase
    {

        #region Fields

        [SerializeField] private GameRoot _gameRoot;
        [SerializeField] private SoundResources _soundResources;

        private Animator _animator;
        private AudioSource _audioSource;
        private NavMeshAgent _navMeshAgent;
        private SelectableObjectBase _harvester;
        private IHarvestable _target;
        private bool _isOnDistance;
        private bool _isHarvesting;
        private float _timeToHarvest;

        #endregion


        #region Properties

        public override CommandName ExecutorCommandName => CommandName.Harvest;

        #endregion


        #region Mono

        public override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _harvester = GetComponent<SelectableObjectBase>();
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
            ResetAniamtion();
        }

        public override void StopExecuteCommand()
        {
            IsCommandRunning = false;
            _navMeshAgent.ResetPath();
            ResetAniamtion();
        }

        public override void TryExecuteCommand(ICommand baseCommand)
        {
            var harvestCommand = (IHarvestCommand)baseCommand;

            _target = harvestCommand.Target;

            CommandHolder.CurrentCommand = CommandName.Harvest;

            ResetAniamtion();
            MoveToTarget();
        }

        private void ResetAniamtion()
        {
            _animator.SetBool(AnimationParams.HAVE_BASKET, false);
            _animator.SetBool(AnimationParams.HARVEST_MIDDLE, false);

            _animator.SetBool(AnimationParams.HAVE_AXE, false);
            _animator.SetBool(AnimationParams.AXE_SLASH_TREE, false);
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

            switch (_target.ResourceType)
            {
                case ResourceType.None:
                    break;

                case ResourceType.Food:
                    _animator.SetBool(AnimationParams.HAVE_BASKET, true);
                    break;

                case ResourceType.Wood:
                    _animator.SetBool(AnimationParams.HAVE_AXE, true);
                    break;

                default:
                    break;
            }
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

            switch (_target.ResourceType)
            {
                case ResourceType.None:
                    break;

                case ResourceType.Food:
                    _animator.SetBool(AnimationParams.HARVEST_MIDDLE, true);
                    break;

                case ResourceType.Wood:
                    _animator.SetBool(AnimationParams.AXE_SLASH_TREE, true);
                    break;

                default:
                    break;
            }
        }

        private void Harvest()
        {
            _timeToHarvest -= Time.deltaTime;

            if (_timeToHarvest < 0.0f)
            {
                Debug.Log("Harvest done");

                switch (_target.ResourceType)
                {
                    case ResourceType.None:
                        break;

                    case ResourceType.Food:
                        _audioSource.PlayOneShot(_soundResources.AppleFall);
                        _gameRoot.Food++;
                        break;

                    case ResourceType.Wood:
                        _audioSource.PlayOneShot(_soundResources.AxeChop);
                        _gameRoot.Wood++;
                        break;

                    default:
                        break;
                }

                _timeToHarvest = _harvester.SecondsToHit;
            }
        }

        #endregion

    }
}