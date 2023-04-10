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


        #region Properties

        public abstract CommandName ExecutorCommandName { get; }
        private protected ICommandHolder CommandHolder { get; set; }

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