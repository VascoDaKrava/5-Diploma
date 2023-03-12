using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace RTDef.UI
{
    public sealed class PointerEvents : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {

        #region Properties

        public event Action OnPointerEnterEvent;
        public event Action OnPointerClickEvent;

        #endregion


        #region IPointer Methods

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClickEvent?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterEvent?.Invoke();
        }

        #endregion

    }
}