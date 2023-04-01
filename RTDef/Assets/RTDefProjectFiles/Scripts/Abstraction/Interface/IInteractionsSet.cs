using UnityEngine;


namespace RTDef.Abstraction.InputSystem
{
    public interface IInteractionsSet
    {

        #region Properties

        IClickableLeft OnLeftDownSetAndInvoke { set; }
        IClickableLeft OnLeftUpSetAndInvoke { set; }
        IClickableRight OnRightDownSetAndInvoke { set; }
        IClickableRight OnRightUpSetAndInvoke { set; }
        float OnWheelScrollingSetAndInvoke { set; }
        float OnHorizontalSetAndInvoke { set; }
        float OnVerticalSetAndInvoke { set; }

        #endregion


        #region Methods

        void SetCursorPosition(Vector3 value);
        void SetHitPoint(Vector3 value);

        #endregion

    }
}