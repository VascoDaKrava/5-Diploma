using RTDef.Abstraction;
using RTDef.UI;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class StartPanelView : MonoLifeCallBacks
    {

        #region Properties

        [field: SerializeField] public CustomPointerEvent StartSingleGameButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent StartMultiplayerButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent OptionsButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent LoginButton { get; private set; }
        [field: SerializeField] public CustomPointerEvent ExitGameButton { get; private set; }

        #endregion

    }
}