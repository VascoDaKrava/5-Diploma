using RTDef.Abstraction;
using RTDef.Audio;
using RTDef.Data.Audio;
using RTDef.Data.Text;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MainMenuRoot : MonoBehaviour, IMainMenuPanels
    {

        #region Properties

        [field: SerializeField] private AudioSource MenuAuidioSource { get; set; }
        [field: SerializeField] private AudioSource MusicAudioSource { get; set; }
        [field: SerializeField] private Transform UIRootTransform { get; set; }

        [field: SerializeField] public InfoPanelView InfoPanel { get; private set; }
        [field: SerializeField] public StartPanelView StartPanel { get; private set; }
        [field: SerializeField] public OptionsPanelView OptionsPanel { get; private set; }
        [field: SerializeField] public LoginPanelView LoginPanel { get; private set; }
        [field: SerializeField] public MultiplayerPanelView MultiplayerPanel { get; private set; }

        [field: SerializeField] private SoundResources SoundResources { get; set; }
        [field: SerializeField] private MainMenuTitles Titles { get; set; }

        #endregion


        #region Mono

        void Start()
        {
            LoadAudioSettings();

            var infoPanelController = new InfoPanelController(this, Titles);
            new StartPanelController(this);
            new OptionsPanelController(StartPanel, OptionsPanel, SoundResources);
            new LoginPanelController(this, infoPanelController);

            new MenuSoundFXController(UIRootTransform, SoundResources, MenuAuidioSource);
            new MusicController(SoundResources, MusicAudioSource);
        }

        #endregion


        #region Methods

        private void LoadAudioSettings()
        {
            SoundResources.Mixer.SetFloat(SoundResources.MenuAudioMixerGroupName, SoundResources.MenuVolume);
            SoundResources.Mixer.SetFloat(SoundResources.SFXAudioMixerGroupName, SoundResources.SFXVolume);
            SoundResources.Mixer.SetFloat(SoundResources.MusicAudioMixerGroupName, SoundResources.MusicVolume);
        }

        #endregion

    }
}