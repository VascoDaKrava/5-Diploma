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

        private bool _createRoomButtonState;
        private bool _leaveRoomButtonState;
        private bool _startGameButtonState;

        private bool _roomListPanelState;
        private bool _roomInfoPanelState;

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
            _multiplayerPanel.OnRoomSelected += OnMultiplayerPanelRoomSelectedHandler;
            _multiplayerPanel.LeaveRoomButton.OnPointerClickEvent += OnLeaveRoomButtonPointerClickEventHandler;

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
            _multiplayerPanel.OnRoomSelected -= OnMultiplayerPanelRoomSelectedHandler;
            _multiplayerPanel.LeaveRoomButton.OnPointerClickEvent -= OnLeaveRoomButtonPointerClickEventHandler;

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
            Debug.Log("OnMatchMakerLeftRoom");
            _multiplayerPanel.StartGameButton.Interactable = false;
            _startGameButtonState = false;

            _multiplayerPanel.LeaveRoomButton.Interactable = false;
            _leaveRoomButtonState = false;

            _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(false);
            _roomInfoPanelState = false;
        }

        private void OnReadyForConfigureRoomHandler()
        {
            Debug.Log("OnReadyForConfigureRoomHandler");
            _multiplayerPanel.CreateRoomButton.Interactable = true;
            _createRoomButtonState = true;
        }

        private void OnMatchMakerReadyToStartHandler()
        {
            Debug.Log("OnMatchMakerReadyToStartHandler");
            _multiplayerPanel.StartGameButton.Interactable = true;
            _startGameButtonState = true;
        }

        private void OnMatchMakerRoomListChangedHandler(List<RoomInfo> roomsList)
        {
            Debug.Log("OnMatchMakerRoomListChangedHandler");
            if (roomsList.Count == 0)
            {
                _multiplayerPanel.RoomsListPanel.gameObject.SetActive(false);
                _roomListPanelState = false;
                return;
            }

            _multiplayerPanel.RoomsListPanel.gameObject.SetActive(true);
            _roomListPanelState = true;
            _multiplayerPanel.FillRoomsList(roomsList);
        }

        private void OnMatchMakerErrorHandler(string message)
        {
            _infoPanel.ShowError(message);
        }

        private void OnMatchMakerCurrentRoomChangeDataHandler(Room room, int playersCount)
        {
            Debug.Log("OnMatchMakerCurrentRoomChangeDataHandler");
            _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(true);
            _roomInfoPanelState = true;
            _multiplayerPanel.ChangeCurrentRoomData(room);
        }

        #endregion

        #region MultiplayerPanelButtons

        private void OnLeaveRoomButtonPointerClickEventHandler()
        {
            _matchMaker.LeaveRoom();
        }

        private void OnMultiplayerPanelRoomSelectedHandler(string roomName)
        {
            Debug.Log("OnMultiplayerPanelRoomSelectedHandler");
            _matchMaker.JoinRoom(roomName);
        }

        private void OnCreateRoomButtonClickHandler()
        {
            Debug.Log("OnCreateRoomButtonClickHandler");
            _multiplayerPanel.LeaveRoomButton.Interactable = true;
            _leaveRoomButtonState = true;
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
            Debug.Log("OnExitClickHandler");
            _matchMaker.LeaveRoom();
            _multiplayerPanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
        }

        #endregion

        private void OnPanelEnableHandler()
        {
            Debug.Log("OnPanelEnableHandler");
            _multiplayerPanel.CreateRoomButton.Interactable = _createRoomButtonState;
            _multiplayerPanel.StartGameButton.Interactable = _startGameButtonState;
            _multiplayerPanel.LeaveRoomButton.Interactable = _leaveRoomButtonState;

            _multiplayerPanel.RoomsListPanel.gameObject.SetActive(_roomListPanelState);
            _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(_roomInfoPanelState);

            _matchMaker.Connect();
        }

        #endregion

    }
}