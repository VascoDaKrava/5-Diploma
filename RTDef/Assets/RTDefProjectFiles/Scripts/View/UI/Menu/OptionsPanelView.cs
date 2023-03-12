using RTDef.Abstraction;
using UnityEngine;
using UnityEngine.UI;


namespace RTDef.Menu
{
    public sealed class OptionsPanelView : MonoLifeCallBacks
    {

        #region Properties

        [field: SerializeField] public Slider MusicVolumeSlider { get; private set; }
        [field: SerializeField] public Slider SFXVolumeSlider { get; private set; }
        [field: SerializeField] public Slider MenuVolumeSlider { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }

        #endregion

    }
}