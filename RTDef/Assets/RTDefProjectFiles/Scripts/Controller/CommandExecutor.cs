using RTDef.Data;
using UnityEngine;


namespace RTDef.UserCommands
{
    public sealed class CommandExecutor
    {


        private readonly InteractionEvents _interactionEvents;
        private readonly SelectedObject _selectedObject;
        private readonly CommandEvents _commandEvents;

        public CommandExecutor(InteractionEvents interactionEvents, SelectedObject selectedObject, CommandEvents commandEvents)
        {
            _interactionEvents = interactionEvents;
            _selectedObject = selectedObject;
            _commandEvents = commandEvents;
            
            selectedObject.OnSelectedChange += (obj) => Debug.Log($"Select {obj}");

            commandEvents.OnRecieveCancel += (cmd) => Debug.Log($"Cancel {cmd}");
            commandEvents.OnRequestExecute += (cmd) => Debug.Log($"Call {cmd}");
            commandEvents.OnStartExecute += (cmd) => Debug.Log($"Start {cmd}");
        }
    }
}