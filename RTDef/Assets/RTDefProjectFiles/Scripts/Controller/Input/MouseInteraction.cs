using RTDef.Abstraction.InputSystem;
using RTDef.Data;
using RTDef.Data.InputSystem;
using System;
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
            _interactionEvents.SetCursorPosition(Input.mousePosition);

            if (Input.GetMouseButtonDown(_inputSettings.MouseLeftButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableLeft>(out var clicked, out var hitPoint))
                {
                    _interactionEvents.OnLeftDownSetAndInvoke = clicked;
                    _interactionEvents.SetHitPoint(hitPoint);
                }
                else
                {
                    _interactionEvents.OnLeftDownSetAndInvoke = null;
                    _interactionEvents.SetHitPoint(default);
                }
            }

            if (Input.GetMouseButtonUp(_inputSettings.MouseLeftButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableLeft>(out var clicked, out var hitPoint))
                {
                    _interactionEvents.OnLeftUpSetAndInvoke = clicked;
                    _interactionEvents.SetHitPoint(hitPoint);
                }
                else
                {
                    _interactionEvents.OnLeftUpSetAndInvoke = null;
                    _interactionEvents.SetHitPoint(default);
                }
            }

            if (Input.GetMouseButtonDown(_inputSettings.MouseRightButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableRight>(out var clicked, out var hitPoint))
                {
                    _interactionEvents.OnRightDownSetAndInvoke = clicked;
                    _interactionEvents.SetHitPoint(hitPoint);
                }
                else
                {
                    _interactionEvents.OnRightDownSetAndInvoke = null;
                    _interactionEvents.SetHitPoint(default);
                }
            }

            if (Input.GetMouseButtonUp(_inputSettings.MouseRightButton))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }

                if (TryHit<IClickableRight>(out var clicked, out var hitPoint))
                {
                    _interactionEvents.OnRightUpSetAndInvoke = clicked;
                    _interactionEvents.SetHitPoint(hitPoint);
                }
                else
                {
                    _interactionEvents.OnRightUpSetAndInvoke = null;
                    _interactionEvents.SetHitPoint(default);
                }
            }

            if (Math.Abs(Input.GetAxis(_inputSettings.MouseWheel)) > 0.0f)
            {
                _interactionEvents.OnWheelScrollingSetAndInvoke = Input.GetAxis(_inputSettings.MouseWheel);
            }
        }

        #endregion


        #region Methods

        private bool TryHit<T>(out T result, out Vector3 hitPoint) where T : class
        {
            RaycastHit[] hits = default;
            result = default;
            hitPoint = default;

            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            if (hits.Length == 0)
            {
                return false;
            }

            foreach (var hit in hits)
            {
                result = hit.collider.GetComponentInParent<T>();

                if (result != null)
                {
                    hitPoint = hit.point;
                    break;
                }
            }

            return result != default;
        }

        #endregion

    }
}