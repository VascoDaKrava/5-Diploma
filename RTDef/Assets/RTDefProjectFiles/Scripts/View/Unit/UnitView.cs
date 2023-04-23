using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using RTDef.Data.Audio;
using RTDef.Enum;
using RTDef.Game.Animations;
using RTDef.Game.UI;
using System;
using UnityEngine;


namespace RTDef.Units
{
    public class UnitView : CommandHolderBase, IClickableLeft, IClickableRight, IAttackable
    {

        #region Events

        public event Action<UnitView> OnDie;

        #endregion


        #region Fields

        private Animator _animator;
        private AudioSource _audioSource;
        [SerializeField, Header("Units data")] public GameBottomInfoView _infoView; // DI
        [SerializeField] private SelectedObject _selectedObject;
        [SerializeField] private SoundResources _soundResources;
        [SerializeField] private Collider _collider;
        private bool _startDie;

        #endregion


        #region Properties

        public Transform AttackTarget => transform;

        public bool isDie => _startDie;

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
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion


        #region Methods

        public void Die()
        {
            CurrentCommand = CommandName.None;

            _animator.SetTrigger(AnimationParams.DIE);
            Destroy(_collider.gameObject);// Destroy collider for stop usage by selector, attacker etc.
            FactionID = 0;// Enemy canm`t attack, friendly-fire
            Destroy(this, Time.deltaTime * 2);// 2 frame pause
            _startDie = true;

            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }

            _audioSource.PlayOneShot(_soundResources.Death);
            _selectedObject.SelectedChange(default);

            OnDie?.Invoke(this);
        }

        #endregion

    }
}