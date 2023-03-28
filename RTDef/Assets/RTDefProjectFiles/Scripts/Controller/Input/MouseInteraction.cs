using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using RTDef.Data.InputSystem;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


namespace RTDef.Inputsystem
{
    public sealed class MouseInteraction : MonoBehaviour
    {

        #region Fields

        [SerializeField] private InputSettings _inputSettings;

        [SerializeField] private InteractionEvents _interactionEvents;
        [SerializeField] private Camera _camera;
        [SerializeField] private EventSystem _eventSystem;

        #endregion


        #region Mono

        private void Update()
        {
            _interactionEvents.SetCursorPosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(_inputSettings.MouseLeftButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableLeft>(out var clicked))
                {
                    _interactionEvents.OnLeftDownSetAndInvoke = clicked;
                }
                else
                {
                    _interactionEvents.OnLeftDownSetAndInvoke = null;
                }
            }

            if (Input.GetMouseButtonUp(_inputSettings.MouseLeftButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableLeft>(out var clicked))
                {
                    _interactionEvents.OnLeftUpSetAndInvoke = clicked;
                }
                else
                {
                    _interactionEvents.OnLeftUpSetAndInvoke = null;
                }
            }

            if (Input.GetMouseButtonDown(_inputSettings.MouseRightButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableRight>(out var clicked))
                {
                    _interactionEvents.OnRightDownSetAndInvoke = clicked;
                }
                else
                {
                    _interactionEvents.OnRightDownSetAndInvoke = null;
                }
            }

            if (Input.GetMouseButtonUp(_inputSettings.MouseRightButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableRight>(out var clicked))
                {
                    _interactionEvents.OnRightUpSetAndInvoke = clicked;
                }
                else
                {
                    _interactionEvents.OnRightUpSetAndInvoke = null;
                }
            }

            if (Math.Abs(Input.GetAxis(_inputSettings.MouseWheel)) > 0.0f)
            {
                _interactionEvents.OnWheelScrollingSetAndInvoke = Input.GetAxis(_inputSettings.MouseWheel);
            }
        }

        #endregion


        #region Methods

        private bool TryHit<T>(out T result) where T : class
        {
            RaycastHit[] hits = default;
            result = default;

            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            if (hits.Length == 0)
            {
                return false;
            }

            result = hits
                .Select(hit => hit.collider.GetComponentInParent<T>())
                .FirstOrDefault(c => c != null);

            return result != default;
        }

        #endregion

    }
}