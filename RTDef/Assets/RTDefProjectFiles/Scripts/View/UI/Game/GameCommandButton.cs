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
        [SerializeField] private ButtonVisualizer _buttonVisualizer;

        #endregion


        #region Properties

        [field: SerializeField] public CommandName Command { get; private set; }

        public bool Interactable
        {
            get => _button.Interactable;
            set => _button.Interactable = value;
        }

        public bool Lock
        {
            set
            {
                _button.Interactable = !value;

                if (value)
                {
                    _buttonVisualizer.SetHighlight();
                }
            }
        }

        #endregion


        #region Mono

        private void OnEnable()
        {
            _button.OnPointerClickEvent += OnButtonClickHandler;
            Interactable = true;
            Lock = false;
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