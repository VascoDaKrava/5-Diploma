using RTDef.Abstraction;
using RTDef.Audio;
using RTDef.Data;
using RTDef.Data.Audio;
using RTDef.Data.Text;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MainMenuRoot : MonoBehaviour, IGameData, IGameState, IGameMainMenuPanels, IGameResources
    {

        #region Fields

        private ProfilePanelController _profilePanelController;

        #endregion


        #region Properties

        [field: SerializeField] private Transform UIRootTransform { get; set; }

        [field: SerializeField] public SoundResources SoundResources { get; private set; }
        [field: SerializeField] public AudioSource MenuAuidioSource { get; private set; }
        [field: SerializeField] public AudioSource MusicAudioSource { get; private set; }

        [field: SerializeField] public AllScenes AllScenes { get; private set; }

        public InfoPanelController InfoPanelController { get; private set; }
        [field: SerializeField] public InfoPanelView InfoPanel { get; private set; }
        [field: SerializeField] public StartPanelView StartPanel { get; private set; }
        [field: SerializeField] public OptionsPanelView OptionsPanel { get; private set; }
        [field: SerializeField] public ProfilePanelView ProfilePanel { get; private set; }
        [field: SerializeField] public MultiplayerPanelView MultiplayerPanel { get; private set; }
        [field: SerializeField] public MainMenuTitles Titles { get; private set; }

        public bool IsClientLoggedIn => _profilePanelController.IsClientLoggedIn;
        public string ClientUserName => _profilePanelController.ClientUserName;

        #endregion


        #region Mono

        private void Start()
        {
            HideAllPanels();
            LoadAudioSettings();

            InfoPanelController = new InfoPanelController(this);
            _profilePanelController = new ProfilePanelController(this);

            new StartPanelController(this);
            new OptionsPanelController(this);
            new MultiplayerPanelController(this);

            new MenuSoundFXController(UIRootTransform, this);
            new MusicController(this);

            SoundResources.ApllySettings();
        }

        #endregion


        #region Methods

        private void HideAllPanels()
        {
            StartPanel.gameObject.SetActive(false);
            MultiplayerPanel.gameObject.SetActive(false);
            OptionsPanel.gameObject.SetActive(false);
            ProfilePanel.gameObject.SetActive(false);
        }

        private void LoadAudioSettings()
        {
            SoundResources.Mixer.SetFloat(SoundResources.MenuAudioMixerGroupName, SoundResources.MenuVolume);
            SoundResources.Mixer.SetFloat(SoundResources.SFXAudioMixerGroupName, SoundResources.SFXVolume);
            SoundResources.Mixer.SetFloat(SoundResources.MusicAudioMixerGroupName, SoundResources.MusicVolume);
        }

        #endregion

    }
}