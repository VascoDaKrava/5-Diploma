using RTDef.Abstraction;
using RTDef.Data.Text;
using System;


namespace RTDef.Menu
{
    public sealed class InfoPanelController : IDisposable
    {

        #region Fields

        private readonly MainMenuTitles _titles;
        private readonly IGameMainMenuPanels _panels;
        private readonly IGameState _gameState;
        private readonly InfoPanelView _info;

        #endregion


        #region CodeLife

        public InfoPanelController(IGame game)
        {
            _panels = game as IGameMainMenuPanels;
            _titles = _panels.Titles;
            _gameState = game as IGameState;
            _info = _panels.InfoPanel;

            _panels.StartPanel.OnEnableEvent += StartPanelOnEnableHandler;
            _panels.ProfilePanel.OnEnableEvent += ProfilePanelOnEnableHandler;
            _panels.MultiplayerPanel.OnEnableEvent += MultiplayerPanelOnEnableHandler;
            _panels.OptionsPanel.OnEnableEvent += OptionsPanelOnEnableHandler;
        }

        public void Dispose()
        {
            _panels.StartPanel.OnEnableEvent -= StartPanelOnEnableHandler;
            _panels.ProfilePanel.OnEnableEvent -= ProfilePanelOnEnableHandler;
            _panels.MultiplayerPanel.OnEnableEvent -= MultiplayerPanelOnEnableHandler;
            _panels.OptionsPanel.OnEnableEvent -= OptionsPanelOnEnableHandler;
        }

        #endregion


        #region Methods

        public void ShowError(string message)
        {
            _info.Message.color = _titles.ErrorColor;
            _info.Message.text = message;
        }

        public void ShowMessage(string message)
        {
            _info.Message.color = _titles.NormalColor;
            _info.Message.text = message;
        }

        public void ShowSuccess(string message)
        {
            _info.Message.color = _titles.SuccessColor;
            _info.Message.text = message;
        }

        private void OptionsPanelOnEnableHandler()
        {
            _info.Title.text = _titles.OptionsPanelTitle;
            ShowMessage("");
        }

        private void MultiplayerPanelOnEnableHandler()
        {
            _info.Title.text = _titles.MultiplayerPanelTitle;
            ShowMessage("");
        }

        private void ProfilePanelOnEnableHandler()
        {
            _info.Title.text = _titles.ProfilePanelTitle;
            var message = _gameState.IsClientLoggedIn ? _titles.ProfilePanelLoggedInMessage : _titles.ProfilePanelNotLoggedInMessage;
            ShowMessage(message);
        }

        private void StartPanelOnEnableHandler()
        {
            _info.Title.text = _titles.StartPanelTitle;
            var message = _gameState.IsClientLoggedIn ? $"Hello, {_gameState.ClientUserName}! {_titles.StartPanelLoggedInMessage}" : _titles.StartPanelNotLoggedInMessage;
            ShowMessage(message);
        }

        #endregion

    }
}