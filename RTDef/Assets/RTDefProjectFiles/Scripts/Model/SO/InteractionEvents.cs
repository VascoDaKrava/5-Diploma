using RTDef.Abstraction.InputSystem;
using System;
using UnityEngine;


namespace RTDef.Data
{
    [CreateAssetMenu(fileName = "InteractionEvents", menuName = "Data/InteractionEvents")]
    public sealed class InteractionEvents : ScriptableObject, IInteractionsGet, IInteractionsSet
    {
        
        #region Events

        public event Action<IClickableLeft> OnLeftDown;
        public event Action<IClickableLeft> OnLeftUp;
        public event Action<IClickableRight> OnRightDown;
        public event Action<IClickableRight> OnRightUp;
        public event Action<float> OnWheelScrolling;
        public event Action<float> OnHorizontal;
        public event Action<float> OnVertical;

        #endregion


        #region Fields

        private Vector3 _cursorPosition;

        #endregion


        #region Properties

        public IClickableLeft OnLeftDownSetAndInvoke { set => OnLeftDown?.Invoke(value); }
        public IClickableLeft OnLeftUpSetAndInvoke { set => OnLeftUp?.Invoke(value); }
        public IClickableRight OnRightDownSetAndInvoke { set => OnRightDown?.Invoke(value); }
        public IClickableRight OnRightUpSetAndInvoke { set => OnRightUp?.Invoke(value); }
        public float OnWheelScrollingSetAndInvoke { set => OnWheelScrolling?.Invoke(value); }
        public Vector3 GetCursorPosition => _cursorPosition;
        public Vector3 SetCursorPosition { set => _cursorPosition = value; }

        public float OnHorizontalSetAndInvoke { set => OnHorizontal(value); }
        public float OnVerticalSetAndInvoke { set => OnVertical(value); }

        #endregion

    }
}