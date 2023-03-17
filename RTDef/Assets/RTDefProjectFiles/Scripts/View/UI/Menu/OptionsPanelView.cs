using RTDef.Abstraction;
using RTDef.UI;
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
        [field: SerializeField] public CustomPointerEvent ExitButton { get; private set; }

        #endregion

    }
}