using RTDef.Enum;
using System;
using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public abstract class CommandExecutorBase : MonoBehaviour
    {

        #region Events

        public event Action OnStartExecute;
        public event Action OnStopExecute;

        #endregion


        #region Fields

        private bool _isCommandRunning = false;

        #endregion


        #region Properties

        public abstract CommandName ExecutorCommandName { get; }
        private protected ICommandHolder CommandHolder { get; set; }
        private protected bool IsCommandRunning
        {
            get => _isCommandRunning;

            set
            {
                _isCommandRunning = value;

                if (value)
                {
                    OnStartExecute?.Invoke();
                }
                else
                {
                    OnStopExecute?.Invoke();
                }
            }
        }

        #endregion


        #region Mono

        public virtual void Awake()
        {
            CommandHolder = GetComponent<ICommandHolder>();
        }

        #endregion


        #region Methods

        public abstract void TryExecuteCommand(ICommand command);
        public abstract void StopExecuteCommand();

        #endregion

    }
}