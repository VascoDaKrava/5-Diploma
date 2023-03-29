using RTDef.Abstraction;
using RTDef.Audio;
using RTDef.Data;
using RTDef.Data.Audio;
using RTDef.Game.UI;
using RTDef.UserCommands;
using UnityEngine;


namespace RTDef.Game
{
    public sealed class GameRoot : MonoBehaviour, IGameData, IGameResources, IInGamePanels, IGameGathering
    {

        #region Fields

        [SerializeField, Space, Header("Data")] private InteractionEvents _interactionEvents;
        [SerializeField] private SelectedObject _selectedObject;
        [SerializeField] private CommandEvents _commandEvents;

        public int Food => 0;
        public int Wood => 12345;

        #endregion


        #region Properties

        [field: SerializeField, Space] private Transform UIRootTransform { get; set; }

        [field: SerializeField, Header("Audio")] public SoundResources SoundResources { get; private set; }
        [field: SerializeField] public AudioSource MenuAuidioSource { get; private set; }
        [field: SerializeField] public AudioSource MusicAudioSource { get; private set; }

        [field: SerializeField, Header("Scenes")] public AllScenes AllScenes { get; private set; }

        [field: SerializeField, Header("UI")] public GameTopPanelView GameTopPanelView { get; private set; }

        [field: SerializeField] public GameBottomPanelView GameBottomPanelView { get; private set; }

        #endregion


        #region Mono

        private void Start()
        {
            new GameUIController(_selectedObject, this);

            new MenuSoundFXController(UIRootTransform, this);
            new MusicController(this);

            new ObjectSelector(_interactionEvents, _selectedObject);

            new CommandExecutor(_interactionEvents, _selectedObject, _commandEvents);

            SoundResources.ApllySettings();
        }

        private void OnEnable()
        {
            _interactionEvents.OnLeftDown += (obj) => Debug.Log("L -> " + obj);
            _interactionEvents.OnRightDown += (obj) => Debug.Log("R -> " + obj);
        }

        #endregion

    }
}