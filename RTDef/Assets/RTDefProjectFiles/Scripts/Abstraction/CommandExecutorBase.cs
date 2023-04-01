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

        [field: SerializeField] public CommandName CommandName { get; private set; }

        #endregion


        #region Methods

        public abstract void TryExecuteCommand(ICommand command);
        public abstract void Stop();

        #endregion

    }
}