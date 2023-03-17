using RTDef.UI;
using System;
using TMPro;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MultiplayerRoomTemplateView : MonoBehaviour
    {

        #region Events

        public event Action<string> OnRoomClick;

        #endregion


        #region Fields

        [SerializeField] private TMP_Text _roomData;
        [SerializeField] private CustomPointerEvent _roomButton;

        #endregion


        #region Properties

        [field: SerializeField] public TMP_Text RoomName { get; private set; }

        #endregion


        #region Mono

        private void OnEnable()
        {
            _roomButton.OnPointerClickEvent += OnPointerRoomButtonClickEventHandler;
        }

        private void OnDisable()
        {
            _roomButton.OnPointerClickEvent -= OnPointerRoomButtonClickEventHandler;
        }

        #endregion


        #region Methods

        public void SetData(string name, int players, int maxPlayers, bool isOpen)
        {
            RoomName.text = name;
            _roomData.text = $"({players} / {maxPlayers}) {(isOpen ? "Open" : "Lock")}";
        }

        private void OnPointerRoomButtonClickEventHandler()
        {
            OnRoomClick?.Invoke(RoomName.text);
        }

        #endregion

    }
}