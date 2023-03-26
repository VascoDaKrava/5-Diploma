using UnityEngine;


namespace RTDef.Game.UI
{
    public sealed class GameBottomPanelView : MonoBehaviour
    {

        #region Properties

        [field: SerializeField] public GameBottomInfoView InfoView { get; private set; }
        [field: SerializeField] public GameBottomCommandView CommandsView { get; private set; }

        #endregion

    }
}