using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace RTDef.Photon
{
    public sealed class PUN_MatchMaker : MonoBehaviourPunCallbacks
    {

        #region Fields

        private const int ROOM_NUMBER_MIN = 1000;
        private const int ROOM_NUMBER_MAX = 9999;
        private const int PLAYER_TTL = 10000;

        #endregion


        #region Events

        public event Action OnReadyForConfigureRoom;
        public event Action<List<RoomInfo>> OnRoomListChanged;
        public event Action<Room> OnCurrentRoomChangeData;
        public event Action<string> OnError;
        public event Action OnReadyToStart;
        public event Action OnLeftMyRoom;
        public event Action OnStartGame;

        #endregion


        #region Properties

        public string UserName { get; set; }
        public float LoadingProgress => PhotonNetwork.LevelLoadingProgress;

        #endregion


        #region PUN Callbacks

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            PhotonNetwork.JoinLobby();// next --> OnJoinedLobby
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();// Ready to create or join room
            OnReadyForConfigureRoom?.Invoke();
        }

        public override void OnLeftLobby()
        {
            base.OnLeftLobby();
            Debug.LogWarning("OnLeftLobby");
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            base.OnRoomListUpdate(roomList);
            OnRoomListChanged?.Invoke(roomList);
        }

        public override void OnPlayerEnteredRoom(Player otherPlayer)
        {
            base.OnPlayerEnteredRoom(otherPlayer);
            OnCurrentRoomChangeData?.Invoke(PhotonNetwork.CurrentRoom);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            PhotonNetwork.LocalPlayer.NickName = UserName;
            OnCurrentRoomChangeData?.Invoke(PhotonNetwork.CurrentRoom);

            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                OnReadyToStart?.Invoke();
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            OnError?.Invoke(message);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            OnError?.Invoke(message);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            OnCurrentRoomChangeData?.Invoke(PhotonNetwork.CurrentRoom);
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            OnLeftMyRoom?.Invoke();
        }

        #endregion


        #region Methods

        public void StartGame(string scene)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
            {
                OnError?.Invoke("Too few players");
                return;
            }

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.LoadLevel(scene);
                OnStartGame?.Invoke();
            }
        }

        public void JoinRoom(string roomName)
        {
            PhotonNetwork.JoinRoom(roomName);// next --> OnJoinedRoom
        }

        public void CreateRoom(byte maxPlayers)
        {
            ConfigureRoom(out var roomName, out var roomOptions, maxPlayers);
            PhotonNetwork.CreateRoom(roomName, roomOptions);// next --> OnJoinedRoom
        }

        public void LeaveRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();// next --> OnConnectedToMaster
            }
        }

        public void Connect()
        {
            if (PhotonNetwork.IsConnected)
            {
                //PhotonNetwork.
                OnReadyForConfigureRoom?.Invoke();
                return;
            }

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
            PhotonNetwork.ConnectUsingSettings();// next --> OnConnectedToMaster
        }

        private void ConfigureRoom(out string roomName, out RoomOptions roomOptions, byte maxPlayers)
        {
            roomName = $"Room {Random.Range(ROOM_NUMBER_MIN, ROOM_NUMBER_MAX)}";
            roomOptions = new RoomOptions
            {
                MaxPlayers = maxPlayers,
                PlayerTtl = PLAYER_TTL,

            };
        }

        #endregion

    }
}