using Photon.Pun;
using Photon.Realtime;
using RTDef.Abstraction;
using RTDef.Data.Text;
using RTDef.Photon;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MultiplayerPanelController : IDisposable
    {

        #region Enums

        private enum MenuState
        {
            None = 0,
            InactiveAll = 1,
            ReadyToCreateNewRoom = 2,
            ShowRoomList = 3,
            ShowRoomInfo = 4,
            ReadyToStart = 5,
        }

        #endregion


        #region Fields

        private const byte MAX_PLAYERS = 4;

        private readonly MultiplayerPanelView _multiplayerPanel;
        private readonly StartPanelView _startPanel;
        private readonly MainMenuTitles _titles;
        private readonly IGameState _gameState;
        private readonly InfoPanelController _infoPanel;
        private readonly string _multiplayerScene;

        private PUN_MatchMaker _matchMaker;

        private MenuState _currentMenuState = MenuState.None;

        #endregion


        #region CodeLife

        public MultiplayerPanelController(IGame game)
        {
            _multiplayerScene = (game as IGameResources).AllScenes.MultiplayerScene.name;

            var panels = game as IGameMainMenuPanels;

            _gameState = game as IGameState;
            _infoPanel = panels.InfoPanelController;

            _multiplayerPanel = panels.MultiplayerPanel;
            _startPanel = panels.StartPanel;

            _titles = panels.Titles;

            _matchMaker = _multiplayerPanel.MatchMaker;

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
            ChangeMenuState(MenuState.ReadyToCreateNewRoom);
        }

        private void OnReadyForConfigureRoomHandler()
        {
            _matchMaker.UserName = _gameState.ClientUserName;
            ChangeMenuState(MenuState.ReadyToCreateNewRoom);
        }

        private void OnMatchMakerReadyToStartHandler()
        {
            ChangeMenuState(MenuState.ReadyToStart);
        }

        private void OnMatchMakerRoomListChangedHandler(List<RoomInfo> roomsList)
        {
            if (_currentMenuState == MenuState.ShowRoomList)
            {
                if (roomsList.Count == 0)
                {
                    ChangeMenuState(MenuState.ReadyToCreateNewRoom);
                }
                else
                {
                    _multiplayerPanel.FillRoomsList(roomsList);
                }
            }
            else
            {
                _multiplayerPanel.FillRoomsList(roomsList);

                if (roomsList.Count > 0)
                {
                    ChangeMenuState(MenuState.ShowRoomList);
                }
            }
        }

        private void OnMatchMakerErrorHandler(string message)
        {
            _infoPanel.ShowError(message);
        }

        private void OnMatchMakerCurrentRoomChangeDataHandler(Room room)
        {
            if (_currentMenuState != MenuState.ReadyToStart)
            {
                ChangeMenuState(MenuState.ShowRoomInfo);
            }

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
            _matchMaker.JoinRoom(roomName);
        }

        private void OnCreateRoomButtonClickHandler()
        {
            _matchMaker.CreateRoom(MAX_PLAYERS);
        }

        private void OnStartGameButtonClickHandler()
        {
            _matchMaker.StartGame(_multiplayerScene);
            Debug.LogFormat("<color=yellow>Call : {0} {1}</color>", "START", _multiplayerScene);
        }

        private void OnExitClickHandler()
        {
            ChangeMenuState(MenuState.None);
            _matchMaker.LeaveRoom();
            _multiplayerPanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
        }

        #endregion

        private void OnPanelEnableHandler()
        {
            ChangeMenuState(MenuState.InactiveAll);
            _matchMaker.Connect();
        }

        private void ChangeMenuState(MenuState state)
        {
            if (_currentMenuState == state)
            {
                return;
            }

            _currentMenuState = state;

            switch (state)
            {
                case MenuState.ShowRoomList:
                    _multiplayerPanel.CreateRoomButton.Interactable = true;
                    _multiplayerPanel.StartGameButton.Interactable = false;
                    _multiplayerPanel.LeaveRoomButton.Interactable = false;
                    _multiplayerPanel.RoomsListPanel.gameObject.SetActive(true);
                    _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(false);
                    _infoPanel.ShowMessage(_titles.MultiplayerPanelJoin);
                    break;
                case MenuState.ShowRoomInfo:
                    _multiplayerPanel.CreateRoomButton.Interactable = false;
                    _multiplayerPanel.StartGameButton.Interactable = false;
                    _multiplayerPanel.LeaveRoomButton.Interactable = true;
                    _multiplayerPanel.RoomsListPanel.gameObject.SetActive(false);
                    _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(true);
                    _infoPanel.ShowMessage(_titles.MultiplayerPanelOtherStart);
                    break;
                case MenuState.ReadyToCreateNewRoom:
                    _multiplayerPanel.CreateRoomButton.Interactable = true;
                    _multiplayerPanel.StartGameButton.Interactable = false;
                    _multiplayerPanel.LeaveRoomButton.Interactable = false;
                    _multiplayerPanel.RoomsListPanel.gameObject.SetActive(false);
                    _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(false);
                    _infoPanel.ShowMessage(_titles.MultiplayerPanelCreateRoom);
                    break;
                case MenuState.ReadyToStart:
                    _multiplayerPanel.CreateRoomButton.Interactable = false;
                    _multiplayerPanel.StartGameButton.Interactable = true;
                    _multiplayerPanel.LeaveRoomButton.Interactable = true;
                    _multiplayerPanel.RoomsListPanel.gameObject.SetActive(false);
                    _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(true);
                    _infoPanel.ShowMessage(_titles.MultiplayerPanelStart);
                    break;
                case MenuState.None:
                    break;
                case MenuState.InactiveAll:
                    _multiplayerPanel.CreateRoomButton.Interactable = false;
                    _multiplayerPanel.StartGameButton.Interactable = false;
                    _multiplayerPanel.LeaveRoomButton.Interactable = false;
                    _multiplayerPanel.RoomsListPanel.gameObject.SetActive(false);
                    _multiplayerPanel.RoomInfoPanel.gameObject.SetActive(false);
                    _infoPanel.ShowMessage(_titles.MultiplayerPanelConnecting);
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}