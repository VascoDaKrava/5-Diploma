using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Enum;
using UnityEngine;
using UnityEngine.AI;


namespace RTDef.Game.Commands
{
    public sealed class AttackCommandExecutor : CommandExecutorBase
    {

        #region Fields

        private SelectableObjectBase _attacker;
        private NavMeshAgent _navMeshAgent;

        #endregion


        #region Properties

        public override CommandName ExecutorCommandName => CommandName.Attack;

        #endregion


        #region Mono

        public override void Awake()
        {
            base.Awake();
            _attacker = GetComponent<SelectableObjectBase>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
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
            var command = (IAttackCommand)baseCommand;

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
                _navMeshAgent.SetDestination(command.AttackTarget.position);
            }
            else
            {
                if (Vector3.Distance(_attacker.transform.position, command.AttackTarget.position) <= _attacker.Range)
                {
                    Debug.Log("Start attack");
                }
                Debug.Log("We tower");
            }

            IsCommandRunning = true;
            Debug.Log($"Attack {command.AttackTarget}");
        }

        #endregion

    }
}