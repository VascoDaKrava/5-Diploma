using RTDef.Abstraction.InputSystem;
using RTDef.Data.Camera;
using System;
using UnityEngine;


namespace RTDef.Game.Controllers
{
    public sealed class CameraController : IDisposable
    {

        #region Fields

        private readonly Transform _cameraContainer;
        private readonly Transform _cameraObjective;
        private readonly CameraRestrictions _restrictions;
        private readonly IInteractionsGet _interactions;

        #endregion


        #region CodeLife

        public CameraController(Transform cameraContainer, Transform cameraObjective, CameraRestrictions restrictions, IInteractionsGet interactions)
        {
            _cameraContainer = cameraContainer;
            _cameraObjective = cameraObjective;
            _restrictions = restrictions;
            _interactions = interactions;

            _interactions.OnVertical += OnVerticalHandler;
            _interactions.OnHorizontal += OnHorizontalHandler;
            _interactions.OnWheelScrolling += OnWheelScrollingHandler;
        }

        public void Dispose()
        {
            _interactions.OnVertical -= OnVerticalHandler;
            _interactions.OnHorizontal -= OnHorizontalHandler;
            _interactions.OnWheelScrolling -= OnWheelScrollingHandler;
        }

        #endregion


        #region Methods

        private void OnWheelScrollingHandler(float value)
        {
            var newPosition = _cameraObjective.transform.position + _cameraObjective.transform.forward * value * _restrictions.ZoomSpeed;

            if (newPosition.y > _restrictions.ZoomHeightMin &&
                newPosition.y < _restrictions.ZoomHeightMax)
            {
                _cameraObjective.transform.position = newPosition;
            }
        }

        private void OnHorizontalHandler(float value)
        {
            var newPosition = _cameraContainer.transform.position + _cameraContainer.transform.right * value * _restrictions.MooveSpeed;
            
            if (newPosition.x > _restrictions.Xmin &&
                newPosition.x < _restrictions.Xmax)
            {
                _cameraContainer.position = newPosition;
            }
        }

        private void OnVerticalHandler(float value)
        {
            var newPosition = _cameraContainer.transform.position + _cameraContainer.transform.forward * value * _restrictions.MooveSpeed;

            if (newPosition.z > _restrictions.Zmin &&
                newPosition.z < _restrictions.Zmax)
            {
                _cameraContainer.position = newPosition;
            }
        }

        #endregion

    }
}