using Photon.Realtime;
using RTDef.Abstraction;
using RTDef.Photon;
using RTDef.UI;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MultiplayerPanelView : MonoLifeCallBacks
    {

        #region Events

        public event Action<string> OnRoomSelected;

        #endregion


        #region Fields

        [SerializeField] private MultiplayerRoomTemplateView _roomTemplate;

        private List<MultiplayerRoomTemplateView> _roomsList = new List<MultiplayerRoomTemplateView>();

        #endregion


        #region Properties

        [field: SerializeField] public MultiplayerPanelCurrentRoomInfoView RoomInfoPanel { get; private set; }
        [field: SerializeField] public RectTransform RoomsListPanel { get; private set; }

        [field: SerializeField] public RectTransform RoomsListContainer { get; private set; }

        [field: SerializeField] public CustomPointerEvent CreateRoomButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent LeaveRoomButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent StartGameButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent ExitButton { get; private set; }
        [field: SerializeField] public PUN_MatchMaker MatchMaker { get; private set; }

        #endregion


        #region Methods

        public void ChangeCurrentRoomData(Room room)
        {
            RoomInfoPanel.SetData(room.Name, room.MaxPlayers, room.IsOpen, new List<Player>(room.Players.Values));
        }

        public void FillRoomsList(List<RoomInfo> roomsList)
        {
            ClearList();
            FillList(roomsList);
        }

        private void ClearList()
        {
            foreach (var room in _roomsList)
            {
                room.OnRoomClick -= OnRoomClickHandler;
                Destroy(room.gameObject);
            }

            _roomsList.Clear();
        }

        private void FillList(List<RoomInfo> roomsList)
        {
            foreach (var room in roomsList)
            {
                var newRoom = Instantiate(_roomTemplate, RoomsListContainer);
                newRoom.SetData(room.Name, room.PlayerCount, room.MaxPlayers, room.IsOpen);
                newRoom.OnRoomClick += OnRoomClickHandler;
                _roomsList.Add(newRoom);
            }
        }

        private void OnRoomClickHandler(string roomName)
        {
            OnRoomSelected?.Invoke(roomName);
        }

        #endregion

    }
}