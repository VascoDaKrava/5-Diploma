using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MultiplayerPanelCurrentRoomInfoView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private TMP_Text _roomName;
        [SerializeField] private TMP_Text _roomData;
        [SerializeField] private TMP_Text _players;

        #endregion


        #region Methods

        public void SetData(string roomName, int maxPlayers, bool isOpen, List<Player> players)
        {
            _roomName.text = roomName;
            _roomData.text = $"({players.Count} / {maxPlayers}) {(isOpen ? "Open" : "Lock")}"; ;

            string playersList = "";

            foreach (var player in players)
            {
                playersList += $"{player.ActorNumber} {player.NickName} {(player.IsMasterClient ? "(Master)" : "")}\n";
            }

            _players.text = playersList;
        }

        #endregion

    }
}