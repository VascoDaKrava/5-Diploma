using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using RTDef.Enum;
using System;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class CommandExecutorController : IDisposable
    {

        #region Fields

        private readonly SelectedObject _selectedObject;
        private readonly CommandEvents _commandEvents;
        private readonly CommandConcretizator _commandConcretizator;
        
        private CommandHolderBase _currentExecutor;

        #endregion


        #region CodeLife

        public CommandExecutorController(
            IInteractionsGet interactionEvents,
            SelectedObject selectedObject,
            CommandEvents commandEvents
            )
        {
            _selectedObject = selectedObject;
            _commandEvents = commandEvents;

            _commandConcretizator = new CommandConcretizator(interactionEvents);

            _commandEvents.OnRequestExecute += PrepareExecute;
            _commandEvents.OnRecieveCancel += PrepareCancel;
            _selectedObject.OnSelectedChange += PrepareCancel;

            _commandEvents.OnStartExecute += (cmd) => Debug.Log($"Start {cmd}");
        }

        public void Dispose()
        {
            _commandEvents.OnRequestExecute -= PrepareExecute;
            _commandEvents.OnRecieveCancel -= PrepareCancel;
            _selectedObject.OnSelectedChange -= PrepareCancel;
        }

        #endregion


        #region Methods

        /// <summary>
        /// When selection change
        /// </summary>
        /// <param name="selectable"></param>
        private void PrepareCancel(SelectableObjectBase _)
        {

        }

        /// <summary>
        /// When recieve Cancel-command from UI
        /// </summary>
        /// <param name="command"></param>
        private void PrepareCancel(CommandName _)
        {

        }

        private void PrepareExecute(CommandName command)
        {
            Debug.Log($"Call {command}");

            _currentExecutor = _selectedObject.CurrentSelected as CommandHolderBase;
            _commandConcretizator.StartGetCommand(command);
            _commandConcretizator.OnCommandReady += OnCommandReadyHandler;
        }

        private void OnCommandReadyHandler(ICommand command)
        {
            _commandConcretizator.OnCommandReady -= OnCommandReadyHandler;
            _currentExecutor.AwailableExecutors[_commandEvents.PendingCommand].TryExecuteCommand(command);
        }

        #endregion

    }
}