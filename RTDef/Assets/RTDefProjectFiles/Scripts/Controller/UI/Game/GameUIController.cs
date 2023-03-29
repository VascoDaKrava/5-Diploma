using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using RTDef.Game.UI;
using System;


namespace RTDef.Game
{
    public sealed class GameUIController : IDisposable
    {

        #region Fields

        private readonly SelectedObject _selectedObject;
        private readonly IGameGathering _gameGathering;
        private readonly GameTopPanelView _topPanel;
        private readonly GameBottomPanelView _bottomPanel;

        #endregion


        #region CodeLife

        public GameUIController(SelectedObject selectedObject, IGameData gameData)
        {
            _selectedObject = selectedObject;
            _gameGathering = gameData as IGameGathering;
            var gamePanels = gameData as IInGamePanels;

            _topPanel = gamePanels.GameTopPanelView;
            _bottomPanel = gamePanels.GameBottomPanelView;

            _selectedObject.OnSelectedChange += OnSelectObject;

            _topPanel.MenuButton.OnPointerClickEvent += TopPanelMenuButtonClickEventHandler;

            _bottomPanel.ShowContent(null);
        }

        public void Dispose()
        {
            _selectedObject.OnSelectedChange -= OnSelectObject;

            _topPanel.MenuButton.OnPointerClickEvent -= TopPanelMenuButtonClickEventHandler;
        }

        #endregion


        #region Methods

        private void OnSelectObject(SelectableObjectBase selectedObject)
        {
            _bottomPanel.ShowContent(selectedObject);
        }

        private void TopPanelMenuButtonClickEventHandler()
        {
            _topPanel.SetResourcesQuantity(_gameGathering);
        }

        #endregion

    }
}