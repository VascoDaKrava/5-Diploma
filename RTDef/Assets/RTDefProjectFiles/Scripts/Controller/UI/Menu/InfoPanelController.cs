using RTDef.Abstraction;
using RTDef.Data.Text;
using System;


namespace RTDef.Menu
{
    public sealed class InfoPanelController : IDisposable
    {

        #region Fields

        private readonly IMainMenuPanels _panels;
        private readonly MainMenuTitles _titles;
        private readonly IGameState _gameState;
        private readonly InfoPanelView _info;

        #endregion


        #region CodeLife

        public InfoPanelController(IMainMenuPanels panels, MainMenuTitles titles, IGameState gameState)
        {
            _panels = panels;
            _titles = titles;
            _gameState = gameState;
            _info = panels.InfoPanel;

            _panels.StartPanel.OnEnableEvent += StartPanelOnEnableHandler;
            _panels.LoginPanel.OnEnableEvent += LoginPanelOnEnableHandler;
            _panels.MultiplayerPanel.OnEnableEvent += MultiplayerPanelOnEnableHandler;
            _panels.OptionsPanel.OnEnableEvent += OptionsPanelOnEnableHandler;
        }

        public void Dispose()
        {
            _panels.StartPanel.OnEnableEvent -= StartPanelOnEnableHandler;
            _panels.LoginPanel.OnEnableEvent -= LoginPanelOnEnableHandler;
            _panels.MultiplayerPanel.OnEnableEvent -= MultiplayerPanelOnEnableHandler;
            _panels.OptionsPanel.OnEnableEvent -= OptionsPanelOnEnableHandler;
        }

        #endregion


        #region Methods

        public void ShowError(string message)
        {
            _info.InfoTextField.color = _titles.ErrorColor;
            _info.InfoTextField.text = message;
        }

        public void ShowMessage(string message)
        {
            _info.InfoTextField.color = _titles.NormalColor;
            _info.InfoTextField.text = message;
        }

        public void ShowSuccess(string message)
        {
            _info.InfoTextField.color = _titles.SuccessColor;
            _info.InfoTextField.text = message;
        }

        private void OptionsPanelOnEnableHandler()
        {
            ShowMessage(_titles.OptionsPanelTitle);
        }

        private void MultiplayerPanelOnEnableHandler()
        {
            ShowMessage(_titles.MultiplayerPanelTitle);
        }

        private void LoginPanelOnEnableHandler()
        {
            var message = _gameState.IsClientLoggedIn ? _titles.LoginPanelTitleLoggedIn : _titles.LoginPanelTitleNotLoggedIn;
            ShowMessage(message);
        }

        private void StartPanelOnEnableHandler()
        {
            var message = _gameState.IsClientLoggedIn ? $"Hello, {_gameState.ClientUserName}! {_titles.StartPanelLoggedInTitle}" : _titles.StartPanelNotLoggedInTitle;
            ShowMessage(message);
        }

        #endregion

    }
}