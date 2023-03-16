using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace RTDef.UI
{
    public sealed class PointerEvents : Selectable, IPointerClickHandler
    {

        #region Events

        public event Action OnPointerClickEvent;
        public event Action OnPointerEnterEvent;
        public event Action OnPointerExitEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;
        public event Action<bool> OnInteractableSetEvent;

        #endregion


        #region Properties

        public new bool interactable
        {
            get => base.interactable;
            set
            {
                OnInteractableSetEvent?.Invoke(value);
                base.interactable = value;
            }
        }

        #endregion


        #region Methods

        public void OnPointerClick(PointerEventData eventData)
        {
            if (interactable)
            {
                OnPointerClickEvent?.Invoke();
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            if (interactable)
            {
                OnPointerEnterEvent?.Invoke();
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);

            if (interactable)
            {
                OnPointerExitEvent?.Invoke();
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            if (interactable)
            {
                OnPointerUpEvent?.Invoke();
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            if (interactable)
            {
                OnPointerDownEvent?.Invoke();
            }
        }

        #endregion

    }
}