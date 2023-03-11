using RTDef.Sound;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MainMenuRoot : MonoBehaviour
    {

        #region Properties

        [field: SerializeField] private StartPanelView StartPanelView { get; set; }

        #endregion


        #region UnityMethods

        void Start()
        {
            new StartPanelController(StartPanelView);
            new MenuSoundFXController();
        }

        #endregion


    }
}