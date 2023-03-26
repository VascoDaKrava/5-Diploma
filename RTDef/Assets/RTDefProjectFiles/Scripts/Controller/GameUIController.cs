using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using RTDef.Buildings;
using RTDef.Gathering;
using RTDef.Units;
using System;
using UnityEngine;


namespace RTDef.Game
{
    public sealed class GameUIController : IDisposable
    {

        #region Fields

        private readonly IInteractionsGet _interactionEvents;
        private readonly IInGamePanels _gamePanels;
        private readonly IGameGathering _gameGathering;

        #endregion


        #region CodeLife

        public GameUIController(IInteractionsGet interactionEvents, IGameData gameData)
        {
            _interactionEvents = interactionEvents;
            _gamePanels = gameData as IInGamePanels;
            _gameGathering = gameData as IGameGathering;

            _interactionEvents.OnLeftDown += OnLeftDownHandler;

            _gamePanels.GameTopPanelView.MenuButton.OnPointerClickEvent += TopPanelMenuButtonClickEventHandler;
        }

        public void Dispose()
        {
            _interactionEvents.OnLeftDown += OnLeftDownHandler;

            _gamePanels.GameTopPanelView.MenuButton.OnPointerClickEvent -= TopPanelMenuButtonClickEventHandler;
        }

        #endregion


        #region Methods

        private void OnLeftDownHandler(IClickableLeft selectedObject)
        {
            switch (selectedObject)
            {
                case BuildingView:
                    Debug.Log("Select Building");
                    break;
                case UnitView:
                    Debug.Log("Select Unit");
                    break;
                case GatheringView:
                    Debug.Log("Select Gathering");
                    break;
                default:
                    Debug.Log("Select other");
                    break;
            }
        }

        private void TopPanelMenuButtonClickEventHandler()
        {
            _gamePanels.GameTopPanelView.SetResourcesQuantity(_gameGathering);
        }

        #endregion

    }
}