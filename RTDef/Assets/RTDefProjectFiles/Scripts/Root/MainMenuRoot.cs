using RTDef.Abstraction;
using RTDef.Audio;
using RTDef.Data.Audio;
using RTDef.Data.Text;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class MainMenuRoot : MonoBehaviour, IMainMenuPanels, IGameState
    {

        #region Fields

        private LoginPanelController _loginPanelController;

        #endregion


        #region Properties

        [field: SerializeField] private AudioSource MenuAuidioSource { get; set; }
        [field: SerializeField] private AudioSource MusicAudioSource { get; set; }
        [field: SerializeField] private Transform UIRootTransform { get; set; }

        [field: SerializeField] public InfoPanelView InfoPanel { get; private set; }
        [field: SerializeField] public StartPanelView StartPanel { get; private set; }
        [field: SerializeField] public OptionsPanelView OptionsPanel { get; private set; }
        [field: SerializeField] public LoginPanelView LoginPanel { get; private set; }
        [field: SerializeField] public MultiplayerPanelView MultiplayerPanel { get; private set; }
        [field: SerializeField] public MainMenuTitles Titles { get; private set; }

        [field: SerializeField] private SoundResources SoundResources { get; set; }

        public bool IsClientLoggedIn => _loginPanelController.IsClientLoggedIn;
        public string ClientUserName => _loginPanelController.ClientUserName;

        #endregion


        #region Mono

        void Start()
        {
            HideAllPanels();
            LoadAudioSettings();

            var infoPanelController = new InfoPanelController(this, this);
            _loginPanelController = new LoginPanelController(this, infoPanelController);

            new StartPanelController(this, this);
            new OptionsPanelController(StartPanel, OptionsPanel, SoundResources);
            new MultiplayerPanelController(this, this, infoPanelController);
            
            new MenuSoundFXController(UIRootTransform, SoundResources, MenuAuidioSource);
            new MusicController(SoundResources, MusicAudioSource);
        }

        #endregion


        #region Methods

        private void HideAllPanels()
        {
            StartPanel.gameObject.SetActive(false);
            MultiplayerPanel.gameObject.SetActive(false);
            OptionsPanel.gameObject.SetActive(false);
            LoginPanel.gameObject.SetActive(false);
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