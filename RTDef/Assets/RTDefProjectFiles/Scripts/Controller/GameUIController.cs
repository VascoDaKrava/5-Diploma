using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using RTDef.Game.UI;
using System;


namespace RTDef.Game
{
    public sealed class GameUIController : IDisposable
    {

        #region Fields

        private readonly IInteractionsGet _interactionEvents;
        private readonly IGameGathering _gameGathering;
        private readonly GameTopPanelView _topPanel;
        private readonly GameBottomPanelView _bottomPanel;

        #endregion


        #region CodeLife

        public GameUIController(IInteractionsGet interactionEvents, IGameData gameData)
        {
            _interactionEvents = interactionEvents;
            var gamePanels = gameData as IInGamePanels;
            _gameGathering = gameData as IGameGathering;

            _topPanel = gamePanels.GameTopPanelView;
            _bottomPanel = gamePanels.GameBottomPanelView;

            _interactionEvents.OnLeftDown += OnLeftDownHandler;

            _topPanel.MenuButton.OnPointerClickEvent += TopPanelMenuButtonClickEventHandler;

            _bottomPanel.ShowContent(null);
        }

        public void Dispose()
        {
            _interactionEvents.OnLeftDown += OnLeftDownHandler;

            _topPanel.MenuButton.OnPointerClickEvent -= TopPanelMenuButtonClickEventHandler;
        }

        #endregion


        #region Methods

        private void OnLeftDownHandler(IClickableLeft selectedObject)
        {
            _bottomPanel.ShowContent(selectedObject as IDataForPanel);
        }

        private void TopPanelMenuButtonClickEventHandler()
        {
            _topPanel.SetResourcesQuantity(_gameGathering);
        }

        #endregion

    }
}