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
        Vector3 SetCursorPosition { set; }
        float OnHorizontalSetAndInvoke { set; }
        float OnVerticalSetAndInvoke { set; }

        #endregion

    }
}