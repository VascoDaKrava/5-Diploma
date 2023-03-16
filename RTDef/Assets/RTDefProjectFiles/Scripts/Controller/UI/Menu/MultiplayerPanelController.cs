using Photon.Pun;
using Photon.Realtime;
using RTDef.Abstraction;
using RTDef.Photon;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MultiplayerPanelController : IDisposable
    {

        #region Fields

        private const byte MAX_PLAYERS = 4;

        private readonly MultiplayerPanelView _multiplayerPanel;
        private readonly StartPanelView _startPanel;
        private readonly InfoPanelController _infoPanel;

        private PUN_MatchMaker _matchMaker;

        #endregion


        #region CodeLife

        public MultiplayerPanelController(IMainMenuPanels panels, IGameState gameState, InfoPanelController infoPanel)
        {
            _infoPanel = infoPanel;

            _multiplayerPanel = panels.MultiplayerPanel;
            _startPanel = panels.StartPanel;

            _matchMaker = _multiplayerPanel.MatchMaker;
            _matchMaker.UserName = gameState.ClientUserName;

            _multiplayerPanel.OnEnableEvent += OnPanelEnableHandler;
            _multiplayerPanel.ExitButton.OnPointerClickEvent += OnExitClickHandler;
            _multiplayerPanel.CreateRoomButton.OnPointerClickEvent += OnCreateRoomButtonClickHandler;
            _multiplayerPanel.StartGameButton.OnPointerClickEvent += OnStartGameButtonClickHandler;

            _matchMaker.OnCurrentRoomChangeData += OnMatchMakerCurrentRoomChangeDataHandler;
            _matchMaker.OnError += OnMatchMakerErrorHandler;
            _matchMaker.OnReadyForConfigureRoom += OnReadyForConfigureRoomHandler;
            _matchMaker.OnRoomListChanged += OnMatchMakerRoomListChangedHandler;
            _matchMaker.OnReadyToStart += OnMatchMakerReadyToStartHandler;
            _matchMaker.OnLeftMyRoom += OnMatchMakerLeftRoom;
        }

        public void Dispose()
        {
            _multiplayerPanel.OnEnableEvent -= OnPanelEnableHandler;
            _multiplayerPanel.ExitButton.OnPointerClickEvent -= OnExitClickHandler;
            _multiplayerPanel.CreateRoomButton.OnPointerClickEvent -= OnCreateRoomButtonClickHandler;
            _multiplayerPanel.StartGameButton.OnPointerClickEvent -= OnStartGameButtonClickHandler;

            _matchMaker.OnCurrentRoomChangeData -= OnMatchMakerCurrentRoomChangeDataHandler;
            _matchMaker.OnError -= OnMatchMakerErrorHandler;
            _matchMaker.OnReadyForConfigureRoom -= OnReadyForConfigureRoomHandler;
            _matchMaker.OnRoomListChanged -= OnMatchMakerRoomListChangedHandler;
            _matchMaker.OnReadyToStart -= OnMatchMakerReadyToStartHandler;
            _matchMaker.OnLeftMyRoom -= OnMatchMakerLeftRoom;
        }

        #endregion


        #region Methods

        #region MatchMaker

        private void OnMatchMakerLeftRoom()
        {
            _multiplayerPanel.StartGameButton.interactable = false;
        }

        private void OnReadyForConfigureRoomHandler()
        {
            _multiplayerPanel.CreateRoomButton.interactable = true;
        }

        private void OnMatchMakerReadyToStartHandler()
        {
            _multiplayerPanel.StartGameButton.interactable = true;
        }

        private void OnMatchMakerRoomListChangedHandler(List<RoomInfo> roomsList)
        {
            _multiplayerPanel.FillRoomsList(roomsList);
        }

        private void OnMatchMakerErrorHandler(string message)
        {
            _infoPanel.ShowError(message);
        }

        private void OnMatchMakerCurrentRoomChangeDataHandler(Room room, int playersCount)
        {
            _multiplayerPanel.ChangeCurrentRoomData(room, playersCount);
        }

        #endregion

        #region MultiplayerPanelButtons

        private void OnCreateRoomButtonClickHandler()
        {
            _multiplayerPanel.LeaveRoomButton.interactable = true;
            _matchMaker.CreateRoom(MAX_PLAYERS);
        }

        private void OnStartGameButtonClickHandler()
        {
            Debug.Log("OnStartGameButtonClickHandler");

            PhotonNetwork.CurrentRoom.IsOpen = false;
            //_ui.UpdateCurrentRoomInfo(PhotonNetwork.CurrentRoom, PhotonNetwork.CurrentRoom.PlayerCount);
            Debug.LogFormat("<color=yellow>Call : {0}</color>", "START GAME");

            if (PhotonNetwork.IsMasterClient)
            {
                //PhotonNetwork.LoadLevel(SCENE_GAME_NAME);
            }
        }

        private void OnExitClickHandler()
        {
            _matchMaker.LeaveRoom();
            _multiplayerPanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
        }

        #endregion
        
        private void OnPanelEnableHandler()
        {
            _multiplayerPanel.CreateRoomButton.interactable = false;
            _multiplayerPanel.StartGameButton.interactable = false;
            _multiplayerPanel.LeaveRoomButton.interactable = false;
        }

        #endregion

    }
}