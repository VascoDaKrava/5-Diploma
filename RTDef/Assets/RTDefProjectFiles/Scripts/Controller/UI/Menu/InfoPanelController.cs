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

        #endregion


        #region CodeLife

        public InfoPanelController(IMainMenuPanels panels, MainMenuTitles titles)
        {
            _panels = panels;
            _titles = titles;

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

        private void OptionsPanelOnEnableHandler()
        {
            _panels.InfoPanel.InfoTextField.text = _titles.OptionsPanelTitle;
        }

        private void MultiplayerPanelOnEnableHandler()
        {
            throw new NotImplementedException();
        }

        private void LoginPanelOnEnableHandler()
        {
            throw new NotImplementedException();
        }

        private void StartPanelOnEnableHandler()
        {
            _panels.InfoPanel.InfoTextField.text = _titles.StartPanelNoLoginTitle;
        }

        #endregion

    }
}