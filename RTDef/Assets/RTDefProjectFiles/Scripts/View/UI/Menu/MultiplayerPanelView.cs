using Photon.Realtime;
using RTDef.Abstraction;
using RTDef.Photon;
using RTDef.UI;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MultiplayerPanelView : MonoLifeCallBacks
    {

        #region Properties

        [field: SerializeField] public PointerEvents CreateRoomButton { get; private set; }
        [field: SerializeField] public PointerEvents LeaveRoomButton { get; private set; }
        [field: SerializeField] public PointerEvents StartGameButton { get; private set; }
        [field: SerializeField] public PointerEvents ExitButton { get; private set; }
        [field: SerializeField] public PUN_MatchMaker MatchMaker { get; private set; }

        #endregion


        #region Methods

        public void ChangeCurrentRoomData(Room room, int playersCount)
        {

        }

        public void FillRoomsList(List<RoomInfo> roomsList)
        {

        }

        #endregion

    }
}