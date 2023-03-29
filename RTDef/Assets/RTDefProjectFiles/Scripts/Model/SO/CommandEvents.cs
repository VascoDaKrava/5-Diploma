using RTDef.Enum;
using System;
using UnityEngine;


namespace RTDef.Data
{
    [CreateAssetMenu(fileName = "CommandEvents", menuName = "Data/CommandEvents")]
    public class CommandEvents : ScriptableObject
    {

        #region Events

        public event Action<CommandName> OnRequestExecute;
        public event Action<CommandName> OnStartExecute;
        public event Action<CommandName> OnRecieveCancel;

        #endregion


        #region Properties

        public CommandName PendingCommand { get; private set; }

        #endregion


        #region Methods

        /// <summary>
        /// Notify that command need execute
        /// </summary>
        /// <param name="command">Pending command</param>
        public void ExecuteRequest(CommandName command)
        {
            PendingCommand = command;
            OnRequestExecute?.Invoke(command);
        }

        /// <summary>
        /// Cancel pending command
        /// </summary>
        public void Cancel()
        {
            OnRecieveCancel?.Invoke(PendingCommand);
            PendingCommand = CommandName.None;
        }

        /// <summary>
        /// Notify that command execution has began
        /// </summary>
        public void InvokeCallback()
        {
            OnStartExecute?.Invoke(PendingCommand);
            PendingCommand = CommandName.None;
        }

        #endregion

    }
}