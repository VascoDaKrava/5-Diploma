using RTDef.Abstraction;
using RTDef.Enum;
using RTDef.UI;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Game.UI
{
    public sealed class GameBottomCommandView : MonoBehaviour
    {

        #region Events

        public event Action<CommandName> OnNeedExecuteCommand;

        #endregion


        #region Fields

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
        }

        private void OnDisable()
        {
            foreach (var button in _commandButtons.Values)
            {
                button.OnNeedExecute -= OnNeedExecuteCommandHandler;
            }
        }

        #endregion


        #region Methods

        public void ShowCommands(List<ICommand> commands)
        {
            HideAll();

            foreach (var command in commands)
            {
                _commandButtons[command.Command].gameObject.SetActive(true);
            }
        }

        private void HideAll()
        {
            foreach (var command in _commandButtons.Values)
            {
                command.gameObject.SetActive(false);
            }
        }

        private void OnNeedExecuteCommandHandler(CommandName command)
        {
            OnNeedExecuteCommand?.Invoke(command);
        }

        #endregion

    }
}