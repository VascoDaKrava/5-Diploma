using RTDef.Abstraction;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace RTDef.Menu
{
    public sealed class StartPanelController : IDisposable
    {

        #region Filds
                
        private readonly StartPanelView _startPanelView;
        private readonly IGameMainMenuPanels _panels;
        private readonly IGameState _gameState;
        private readonly string _singleGameScene;

        #endregion


        #region CodeLife

        public StartPanelController(IGameData game)
        {
            _panels = game as IGameMainMenuPanels;
            _gameState = game as IGameState;
            _singleGameScene = (game as IGameResources).AllScenes.SingleGameScene.name;

            _startPanelView = _panels.StartPanel;
            _startPanelView.StartSingleGameButton.OnPointerClickEvent += OnStartSingleClickHandler;
            _startPanelView.StartMultiplayerButton.OnPointerClickEvent += OnStartMultiplayerClickHandler;
            _startPanelView.OptionsButton.OnPointerClickEvent += OnOptionsClickHandler;
            _startPanelView.ProfileButton.OnPointerClickEvent += OnLoginClickHandler;
            _startPanelView.ExitGameButton.OnPointerClickEvent += OnExitClickHandler;
            _startPanelView.OnEnableEvent += OnStartPanelViewEnableHandler;

            _startPanelView.gameObject.SetActive(true);
        }

        public void Dispose()
        {
            _startPanelView.StartSingleGameButton.OnPointerClickEvent -= OnStartSingleClickHandler;
            _startPanelView.StartMultiplayerButton.OnPointerClickEvent -= OnStartMultiplayerClickHandler;
            _startPanelView.OptionsButton.OnPointerClickEvent -= OnOptionsClickHandler;
            _startPanelView.ProfileButton.OnPointerClickEvent -= OnLoginClickHandler;
            _startPanelView.ExitGameButton.OnPointerClickEvent -= OnExitClickHandler;
            _startPanelView.OnEnableEvent -= OnStartPanelViewEnableHandler;
        }

        #endregion


        #region Methods

        private void OnStartPanelViewEnableHandler()
        {
            _startPanelView.StartMultiplayerButton.Interactable = _gameState.IsClientLoggedIn;
        }

        private void OnStartSingleClickHandler()
        {
            //_startPanelView.gameObject.SetActive(false);
            //_panels.InfoPanel.gameObject.SetActive(false);
            SceneManager.LoadScene(_singleGameScene);
            Debug.LogFormat("<color=yellow>Call : {0} {1}</color>", "START", _singleGameScene);
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
            _panels.ProfilePanel.gameObject.SetActive(true);
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