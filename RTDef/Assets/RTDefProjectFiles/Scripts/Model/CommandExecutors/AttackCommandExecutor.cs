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
    public sealed class AttackCommandExecutor : CommandExecutorBase
    {

        #region Fields

        [SerializeField] private SoundResources _soundResources;

        /// <summary>
        /// Get from NavMeshAgent at Awake
        /// </summary>
        private float _stopDistancePrimary;

        private bool _isOnDistance;
        private bool _isAttacking;
        private float _timeToHit = 0.0f;
        private SelectableObjectBase _attacker;
        private Animator _animator;
        private AudioSource _audioSource;
        private NavMeshAgent _navMeshAgent;
        private IAttackCommand _attackCommand;

        #endregion


        #region Properties

        public override CommandName ExecutorCommandName => CommandName.Attack;

        #endregion


        #region Mono

        public override void Awake()
        {
            base.Awake();
            _attacker = GetComponent<SelectableObjectBase>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();

            if (TryGetComponent(out _navMeshAgent))
            {
                _stopDistancePrimary = _navMeshAgent.stoppingDistance;
            }
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
                    if (_isAttacking)
                    {
                        DoAttack();
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
            _attackCommand = (IAttackCommand)baseCommand;

            if (_navMeshAgent != null)
            {
                if (_attacker.Range > 0)
                {
                    _navMeshAgent.stoppingDistance = _attacker.Range;
                    Debug.Log("We archer");
                }
                else
                {
                    Debug.Log("We swordsman");
                }

                MoveToTarget();
            }
            else
            {
                if (Vector3.Distance(_attacker.transform.position, _attackCommand.AttackableTarget.AttackTarget.position) <= _attacker.Range)
                {
                    Debug.Log("Start attack");
                }
                Debug.Log("We tower");
            }

            CommandHolder.CurrentCommand = CommandName.Attack;
            Debug.Log($"Attack {_attackCommand.AttackableTarget}");
        }

        private async void CheckMoveFinishAsync()
        {
            await Task.Run(() => { while (IsCommandRunning && _isOnDistance) { }; });
            Debug.Log("Move to target finish");
            _isOnDistance = false;
            _isAttacking = true;
        }

        private void MoveToTarget()
        {
            _navMeshAgent.SetDestination(_attackCommand.AttackableTarget.AttackTarget.position);
            _isAttacking = false;
            //_timeToHit = _attacker.SecondsToHit;
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

        private void DoAttack()
        {
            //if (_attackCommand.AttackableTarget == null)
            if (_attackCommand.AttackableTarget.isDie)
            {
                Debug.Log("Target die");
                CommandFinish();
                return;
            }

            if (Vector3.Distance(_navMeshAgent.transform.position, _attackCommand.AttackableTarget.AttackTarget.position) > (_attacker.Range > 0 ? _attacker.Range : _stopDistancePrimary))
            {
                MoveToTarget();
                return;
            }

            _timeToHit -= Time.deltaTime;

            if (_timeToHit < 0.0f)
            {
                Debug.Log("Make hit");
                _animator.SetTrigger(AnimationParams.FIRE);

                if (_attacker.Range > 0)
                {
                    _audioSource.PlayOneShot(_soundResources.ArrowFlyClip);
                }
                else
                {
                    _audioSource.PlayOneShot(_soundResources.HalbertAttackClip);
                }

                if (!_attackCommand.AttackableTarget.GetDamage(_attacker.Attack))
                {
                    Debug.Log("Attack CommandFinish");
                    CommandFinish();
                }

                _timeToHit = _attacker.SecondsToHit;
            }
        }

        #endregion

    }
}