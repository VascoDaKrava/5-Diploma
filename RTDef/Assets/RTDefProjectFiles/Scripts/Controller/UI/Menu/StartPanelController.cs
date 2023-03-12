using RTDef.Abstraction;
using System;
using UnityEditor;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class StartPanelController : IDisposable
    {

        #region Filds
                
        private readonly StartPanelView _startPanelView;
        private readonly IMainMenuPanels _panels;

        #endregion


        #region CodeLife

        public StartPanelController(IMainMenuPanels panels)
        {
            _panels = panels;

            _startPanelView = _panels.StartPanel;
            _startPanelView.StartSingleGameButton.onClick.AddListener(OnStartSingleClickHandler);
            _startPanelView.StartMultiplayerButton.onClick.AddListener(OnStartMultiplayerClickHandler);
            _startPanelView.OptionsButton.onClick.AddListener(OnOptionsClickHandler);
            _startPanelView.LoginButton.onClick.AddListener(OnLoginClickHandler);
            _startPanelView.ExitGameButton.onClick.AddListener(OnExitClickHandler);

            _startPanelView.gameObject.SetActive(true);
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
            //_startPanelView.gameObject.SetActive(false);
            //_panels.InfoPanel.gameObject.SetActive(false);
            Debug.Log("OnStartSingle");
        }

        private void OnStartMultiplayerClickHandler()
        {
            _startPanelView.gameObject.SetActive(false);
            _panels.MultiplayerPanel.gameObject.SetActive(true);
        }

        private void OnOptionsClickHandler()
        {
            _startPanelView.gameObject.SetActive(false);
            _panels.OptionsPanel.gameObject.SetActive(true);
        }

        private void OnLoginClickHandler()
        {
            _startPanelView.gameObject.SetActive(false);
            _panels.LoginPanel.gameObject.SetActive(true);
        }

        private void OnExitClickHandler()
        {
            if (Application.isEditor)
            {
                EditorApplication.isPlaying = false;
            }

            Application.Quit();
        }

        #endregion

    }
}