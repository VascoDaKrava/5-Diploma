using System;
using UnityEngine;


namespace RTDef.Abstraction.InputSystem
{
    public interface IInteractionsGet
    {

        #region Fields

        event Action<IClickableLeft> OnLeftDown;
        event Action<IClickableLeft> OnLeftUp;
        event Action<IClickableRight> OnRightDown;
        event Action<IClickableRight> OnRightUp;
        event Action<float> OnWheelScrolling;
        event Action<float> OnHorizontal;
        event Action<float> OnVertical;

        #endregion


        #region Properties

        Vector3 GetCursorPosition { get; }

        #endregion

    }
}