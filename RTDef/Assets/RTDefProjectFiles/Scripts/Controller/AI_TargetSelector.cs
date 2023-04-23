using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Game.Commands;
using RTDef.Units;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.AI
{
    public sealed class AI_TargetSelector : UnitView
    {

        #region Fields

        [SerializeField, Header("AI_TargetSelector data")] private float _searchRadius = 30.0f;

        /// <summary>
        /// Time to next search in seconds
        /// </summary>
        [SerializeField] private float _timeToSearch = 5.0f;
        private float _timeElapsed = 5.0f;
        private bool _waitForSearch = true;

        [SerializeField] private int _layerForUnits = 6;

        private AttackCommandExecutor _commandExecutor;
        private int _factionID;
        private HashSet<IAttackable> _targets = new HashSet<IAttackable>();

        #endregion


        #region Mono

        private protected override void Awake()
        {
            base.Awake();
            _commandExecutor = GetComponent<AttackCommandExecutor>();
            _factionID = GetComponent<IFaction>().FactionID;
        }

        private void Update()
        {
            if (_waitForSearch)
            {
                _timeElapsed -= Time.deltaTime;

                if (_timeElapsed < 0.0f)
                {
                    _waitForSearch = false;
                    _timeElapsed = _timeToSearch;
                    GetTarget();
                }
            }
        }

        private void OnEnable()
        {
            _commandExecutor.OnStopExecute += OnStopExecuteHandler;
        }

        private void OnDisable()
        {
            _commandExecutor.OnStopExecute -= OnStopExecuteHandler;
        }

        #endregion


        #region Methods

        private void OnStopExecuteHandler()
        {
            _waitForSearch = true;
        }

        private void GetTarget()
        {
            _targets.Clear();

            var targetColliders = Physics.OverlapSphere(transform.position, _searchRadius, (1 << _layerForUnits));

            foreach (var item in targetColliders)
            {
                var attackable = item.GetComponentInParent<IAttackable>();
                if (attackable != null)
                {
                    if (item.GetComponentInParent<IFaction>().FactionID != _factionID)
                    {
                        _targets.Add(attackable);
                    }
                }
            }

            float distanceToTarget = float.PositiveInfinity;
            IAttackable target = default;

            foreach (var item in _targets)
            {
                var tempDistance = Vector3.Distance(transform.position, item.AttackTarget.position);
                if (tempDistance < distanceToTarget)
                {
                    distanceToTarget = tempDistance;
                    target = item;
                }
            }

            if (target != null)
            {
                Debug.Log($"Enemy select {target} as target!");
                _commandExecutor.TryExecuteCommand(new AttackCommand { AttackableTarget = target });
            }
            else
            {
                Debug.Log("Enemy wait fo search.");
                _waitForSearch = true;
            }
        }

        #endregion

    }
}