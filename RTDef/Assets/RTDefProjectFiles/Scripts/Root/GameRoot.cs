using RTDef.Abstraction;
using RTDef.Audio;
using RTDef.Data;
using RTDef.Data.Audio;
using RTDef.Data.Camera;
using RTDef.Game.Commands;
using RTDef.Game.Controllers;
using RTDef.Game.UI;
using UnityEngine;


namespace RTDef.Game
{
    public sealed class GameRoot : MonoBehaviour, IGameData, IGameResources, IInGamePanels, IHarvestingResources
    {

        #region Fields

        [SerializeField, Space, Header("Data")] private InteractionEvents _interactionEvents;
        [SerializeField] private SelectedObject _selectedObject;
        [SerializeField] private CommandEvents _commandEvents;

        [SerializeField, Space, Header("Camera")] private Transform _cameraContainer;
        [SerializeField] private Transform _cameraObjective;
        [SerializeField] private CameraRestrictions _cameraRestrictions;

        [SerializeField] private int _food = 100;
        [SerializeField] private int _wood = 100;
        private GameUIController _gameUIcontroller;

        #endregion


        #region Properties

        [field: SerializeField, Space] private Transform UIRootTransform { get; set; }

        [field: SerializeField, Header("Audio")] public SoundResources SoundResources { get; private set; }
        [field: SerializeField] public AudioSource MenuAuidioSource { get; private set; }
        [field: SerializeField] public AudioSource MusicAudioSource { get; private set; }

        [field: SerializeField, Header("Scenes")] public AllScenes AllScenes { get; private set; }

        [field: SerializeField, Header("UI")] public GameTopPanelView GameTopPanelView { get; private set; }

        [field: SerializeField] public GameBottomPanelView GameBottomPanelView { get; private set; }

        public int Food
        {
            get
            {
                return _food;
            }

            set
            {
                _food = value;
                _gameUIcontroller.UpdateHarvestingResources(this);
            }
        }

        public int Wood
        {
            get
            {
                return _wood;
            }

            set
            {
                _wood = value;
                _gameUIcontroller.UpdateHarvestingResources(this);
            }
        }

        #endregion


        #region Mono

        private void Start()
        {
            //SetDefaultsForSO();

            _gameUIcontroller = new GameUIController(_selectedObject, this);

            new MenuSoundFXController(UIRootTransform, this);
            new MusicController(this);

            new ObjectSelector(_interactionEvents, _selectedObject);

            new CommandExecutorController(_interactionEvents, _selectedObject, _commandEvents);

            new CameraController(_cameraContainer, _cameraObjective, _cameraRestrictions, _interactionEvents);

            SoundResources.ApllySettings();
            _gameUIcontroller.UpdateHarvestingResources(this);
        }

        private void OnEnable()
        {
            _interactionEvents.OnLeftDown += (obj) => Debug.Log("L -> " + obj);
            _interactionEvents.OnRightDown += (obj) => Debug.Log("R -> " + obj);
        }

        private void OnDisable()
        {
            SetDefaultsForSO();
        }

        #endregion


        #region Methods

        private void SetDefaultsForSO()
        {
            _selectedObject.SelectedChange(default);

            if (_commandEvents.PendingCommand != Enum.CommandName.None)
            {
                _commandEvents.Cancel();
            }
        }

        #endregion

    }
}