using System;


namespace RTDef.Menu
{
    public sealed class StartPanelController : IDisposable
    {

        #region Filds

        private readonly StartPanelView _startPanelView;

        #endregion


        #region CodeLifeCycles

        public StartPanelController(StartPanelView startPanelView)
        {
            _startPanelView = startPanelView;

            _startPanelView.StartSingleGameButton.onClick.AddListener(OnStartSingleClickHandler);
            _startPanelView.StartMultiplayerButton.onClick.AddListener(OnStartMultiplayerClickHandler);
            _startPanelView.OptionsButton.onClick.AddListener(OnOptionsClickHandler);
            _startPanelView.LoginButton.onClick.AddListener(OnLoginClickHandler);
            _startPanelView.ExitGameButton.onClick.AddListener(OnExitClickHandler);
        }

        public void Dispose()
        {
            _startPanelView.StartSingleGameButton.onClick.RemoveListener(OnStartSingleClickHandler);
            _startPanelView.StartMultiplayerButton.onClick.RemoveListener(OnStartMultiplayerClickHandler);
            _startPanelView.OptionsButton.onClick.RemoveListener(OnOptionsClickHandler);
            _startPanelView.LoginButton.onClick.RemoveListener(OnLoginClickHandler);
            _startPanelView.ExitGameButton.onClick.RemoveListener(OnExitClickHandler);
        }

        #endregion


        #region Methods

        private void OnStartSingleClickHandler()
        {

        }

        private void OnStartMultiplayerClickHandler()
        {

        }

        private void OnOptionsClickHandler()
        {

        }

        private void OnLoginClickHandler()
        {

        }

        private void OnExitClickHandler()
        {

        }

        #endregion

    }
}