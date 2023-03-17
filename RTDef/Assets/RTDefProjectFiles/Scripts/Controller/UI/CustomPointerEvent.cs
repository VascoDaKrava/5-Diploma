using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace RTDef.UI
{
    public class CustomPointerEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {

        [SerializeField] private Selectable _selectable;

        #region Events

        public event Action OnPointerClickEvent;
        public event Action OnPointerEnterEvent;
        public event Action OnPointerExitEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;
        public event Action<bool> OnInteractableSetEvent;

        #endregion


        #region Properties

        public bool Interactable
        {
            get => _selectable.interactable;
            set
            {
                OnInteractableSetEvent?.Invoke(value);
                _selectable.interactable = value;
            }
        }

        #endregion


        #region Methods

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Interactable)
            {
                OnPointerClickEvent?.Invoke();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Interactable)
            {
                OnPointerEnterEvent?.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (Interactable)
            {
                OnPointerExitEvent?.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (Interactable)
            {
                OnPointerUpEvent?.Invoke();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Interactable)
            {
                OnPointerDownEvent?.Invoke();
            }
        }

        #endregion

    }
}