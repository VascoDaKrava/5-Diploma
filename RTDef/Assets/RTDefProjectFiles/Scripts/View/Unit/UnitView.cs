using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using RTDef.Enum;
using RTDef.Game.Animations;
using RTDef.Game.UI;
using UnityEngine;


namespace RTDef.Units
{
    public class UnitView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {

        #region Fields

        private Animator _animator;
        [SerializeField, Header("Units data")] private GameBottomInfoView _infoView;
        [SerializeField] private SelectedObject _selectedObject;

        #endregion


        #region Properties

        public Transform AttackTarget => transform;

        public bool GetDamage(int damage)
        {
            Debug.Log($"{this} get {damage} damage!");
            Health -= damage;
            _infoView.SetLife(Health, HealthMax);

            if (Health > 0)
            {
                return true;
            }

            Die();

            return false;
        }

        #endregion


        #region Mono

        private protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        #endregion


        #region Methods

        public void Die()
        {
            CurrentCommand = CommandName.None;

            _animator.SetTrigger(AnimationParams.DIE);
            Destroy(this, Time.deltaTime * 2);

            _selectedObject.SelectedChange(default);
        }

        #endregion

    }
}