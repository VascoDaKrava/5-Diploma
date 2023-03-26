using UnityEngine;


namespace RTDef.Data.InputSystem
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "Data/InputSettings")]
    public sealed class InputSettings : ScriptableObject
    {

        #region Properties

        [field: SerializeField] public int MouseLeftButton { get; private set; } = 0;
        [field: SerializeField] public int MouseRightButton { get; private set; } = 1;
        [field: SerializeField] public string MouseWheel { get; private set; } = "Mouse ScrollWheel";

        [field: SerializeField] public string AxisHorizontal { get; private set; } = "Horizontal";
        [field: SerializeField] public string AxisVertical { get; private set; } = "Vertical";

        #endregion

    }
}