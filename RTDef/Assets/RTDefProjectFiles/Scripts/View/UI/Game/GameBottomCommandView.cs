using RTDef.Data;
using RTDef.Enum;
using RTDef.UI;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Game.UI
{
    public sealed class GameBottomCommandView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private CommandEvents _commandEvents;

        private Dictionary<CommandName, GameCommandButton> _commandButtons;

        #endregion


        #region Mono

        private void Awake()
        {
            var buttons = gameObject.GetComponentsInChildren<GameCommandButton>();
            _commandButtons = new Dictionary<CommandName, GameCommandButton>(buttons.Length);

            foreach (var button in buttons)
            {
                _commandButtons.Add(button.Command, button);
                button.OnNeedExecute += OnNeedExecuteCommandHandler;
            }

            _commandEvents.OnRecieveCancel += OnRecieveCommandResultHandler;
            _commandEvents.OnStartExecute += OnRecieveCommandResultHandler;
        }

        private void OnDestroy()
        {
            foreach (var button in _commandButtons.Values)
            {
                button.OnNeedExecute -= OnNeedExecuteCommandHandler;
            }

            _commandEvents.OnRecieveCancel -= OnRecieveCommandResultHandler;
            _commandEvents.OnStartExecute -= OnRecieveCommandResultHandler;
        }

        #endregion


        #region Methods

        public void ShowCommands(SortedSet<CommandName> commands)
        {
            HideAll();

            foreach (var command in commands)
            {
                _commandButtons[command].gameObject.SetActive(true);
            }
        }

        private void HideAll()
        {
            foreach (var button in _commandButtons.Values)
            {
                button.gameObject.SetActive(false);
            }
        }

        private void OnNeedExecuteCommandHandler(CommandName command)
        {
            _commandEvents.ExecuteRequest(command);

            if (command == CommandName.Stop)
            {
                OnRecieveCommandResultHandler(default);
                return;
            }

            foreach (var button in _commandButtons)
            {
                if (button.Key == CommandName.Stop)
                {
                    continue;
                }

                if (button.Key == command)
                {
                    button.Value.Lock = true;
                    continue;
                }

                button.Value.Interactable = false;
            }
        }

        private void OnRecieveCommandResultHandler(CommandName _)
        {
            foreach (var button in _commandButtons)
            {
                button.Value.Lock = false;
            }
        }

        #endregion

    }
}