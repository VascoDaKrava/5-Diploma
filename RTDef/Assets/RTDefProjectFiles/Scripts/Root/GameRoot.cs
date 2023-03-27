using RTDef.Abstraction;
using RTDef.Audio;
using RTDef.Data;
using RTDef.Data.Audio;
using RTDef.Game.UI;
using UnityEngine;


namespace RTDef.Game
{
    public sealed class GameRoot : MonoBehaviour, IGameData, IGameResources, IInGamePanels, IGameGathering
    {

        #region Fields

        [SerializeField] private InteractionEvents _interactionEvents;

        #endregion


        #region Properties

        [field: SerializeField] private Transform UIRootTransform { get; set; }

        [field: SerializeField] public SoundResources SoundResources { get; private set; }
        [field: SerializeField] public AudioSource MenuAuidioSource { get; private set; }
        [field: SerializeField] public AudioSource MusicAudioSource { get; private set; }

        [field: SerializeField] public AllScenes AllScenes { get; private set; }

        [field: SerializeField] public GameTopPanelView GameTopPanelView { get; private set; }

        [field: SerializeField] public GameBottomPanelView GameBottomPanelView { get; private set; }

        public int Food => 0;

        public int Wood => 12345;


        #endregion


        #region Mono

        private void Start()
        {
            new GameUIController(_interactionEvents, this);

            new MenuSoundFXController(UIRootTransform, this);
            new MusicController(this);

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