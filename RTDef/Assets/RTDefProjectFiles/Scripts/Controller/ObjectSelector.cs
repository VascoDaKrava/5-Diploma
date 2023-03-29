using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using System;


namespace RTDef.Game
{
    public sealed class ObjectSelector : IDisposable
    {

        #region Fields

        private readonly IInteractionsGet _interactionEvents;
        private readonly SelectedObject _selectedObject;

        #endregion


        #region CodeLife

        public ObjectSelector(IInteractionsGet interactionEvents, SelectedObject selectedObject)
        {
            _interactionEvents = interactionEvents;
            _selectedObject = selectedObject;

            _interactionEvents.OnLeftDown += OnLeftDownHandler;
        }

        public void Dispose()
        {
            _interactionEvents.OnLeftDown -= OnLeftDownHandler;
        }

        #endregion


        #region Methods

        private void OnLeftDownHandler(IClickableLeft selected)
        {
            _selectedObject.SelectedChange(selected as SelectableObjectBase);
        }

        #endregion

    }
}