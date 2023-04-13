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


        #region Properties

        public IClickableLeft OnLeftDownSetAndInvoke { set => OnLeftDown?.Invoke(value); }
        public IClickableLeft OnLeftUpSetAndInvoke { set => OnLeftUp?.Invoke(value); }
        public IClickableRight OnRightDownSetAndInvoke { set => OnRightDown?.Invoke(value); }
        public IClickableRight OnRightUpSetAndInvoke { set => OnRightUp?.Invoke(value); }
        public float OnWheelScrollingSetAndInvoke { set => OnWheelScrolling?.Invoke(value); }
        public Vector3 CursorPosition { get; private set; }
        public Vector3 HitPoint { get; private set; }

        public float OnHorizontalSetAndInvoke { set => OnHorizontal?.Invoke(value); }
        public float OnVerticalSetAndInvoke { set => OnVertical?.Invoke(value); }

        #endregion


        #region Methods

        public void SetCursorPosition(Vector3 value) { CursorPosition = value; }
        public void SetHitPoint(Vector3 value) { HitPoint = value; }

        #endregion

    }
}