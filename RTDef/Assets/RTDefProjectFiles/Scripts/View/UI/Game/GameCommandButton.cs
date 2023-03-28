using RTDef.Abstraction;
using RTDef.Enum;
using System;
using UnityEngine;


namespace RTDef.UI
{
    public sealed class GameCommandButton : MonoBehaviour, ICommand
    {

        #region Events

        public event Action<CommandName> OnNeedExecute;

        #endregion


        #region Fields

        [SerializeField] private CustomPointerEvent _button;

        #endregion


        #region Properties

        [field: SerializeField] public CommandName Command { get; private set; }

        #endregion


        #region Mono

        private void OnEnable()
        {
            _button.OnPointerClickEvent += OnButtonClickHandler;
        }

        private void OnDisable()
        {
            _button.OnPointerClickEvent -= OnButtonClickHandler;
        }

        #endregion


        #region Methods

        private void OnButtonClickHandler()
        {
            OnNeedExecute?.Invoke(Command);
        }

        #endregion

    }
}