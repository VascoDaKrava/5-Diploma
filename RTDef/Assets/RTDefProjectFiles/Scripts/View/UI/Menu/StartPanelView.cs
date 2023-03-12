using RTDef.Abstraction;
using UnityEngine;
using UnityEngine.UI;


namespace RTDef.Menu
{
    public sealed class StartPanelView : MonoLifeCallBacks
    {

        #region Properties

        [field: SerializeField] public Button StartSingleGameButton { get; private set; }
        [field: SerializeField] public Button StartMultiplayerButton { get; private set; }
        [field: SerializeField] public Button OptionsButton { get; private set; }
        [field: SerializeField] public Button LoginButton { get; private set; }
        [field: SerializeField] public Button ExitGameButton { get; private set; }

        #endregion

    }
}