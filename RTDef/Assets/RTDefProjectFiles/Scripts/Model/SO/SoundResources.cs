using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace RTDef.Data.Audio
{
	[CreateAssetMenu(fileName = "AudioResorces", menuName = "Data/AudioResorces")]
	public sealed class SoundResources : ScriptableObject
	{

        #region Properties

        [field: SerializeField, Space] public AudioMixer Mixer { get; private set; }


        #region Volume

        /// <summary>
        /// In dB
        /// </summary>
        [field: SerializeField, Header("Volume Levels in dB"), Tooltip("Float data in dB")] public float MusicVolume { get; set; }
        
        /// <summary>
        /// In dB
        /// </summary>
        [field: SerializeField, Tooltip("Float data in dB")] public float SFXVolume { get; set; }
        
        /// <summary>
        /// In dB
        /// </summary>
        [field: SerializeField, Tooltip("Float data in dB")] public float MenuVolume { get; set; }

        #endregion

        #region Mixer

        [field: SerializeField, Space, Header("Mixer groups")] public string MasterAudioMixerGroupName { get; private set; }
        [field: SerializeField] public string MusicAudioMixerGroupName { get; private set; }
        [field: SerializeField] public string SFXAudioMixerGroupName { get; private set; }
        [field: SerializeField] public string MenuAudioMixerGroupName { get; private set; }

        #endregion

        #region Clips

        [field: SerializeField, Space, Header("Audioclips")] public AudioClip MenuMusic { get; private set; }

        [field: SerializeField] public List<AudioClip> BackgroundMusic { get; private set; }

        [field: SerializeField, Space, Header("Menu")] public AudioClip ButtonSelectClip { get; private set; }
        [field: SerializeField] public AudioClip ButtonClickClip { get; private set; }
        
        [field: SerializeField, Space, Header("SFX"), Header("Weapon")] public AudioClip ArrowFlyClip { get; private set; }
        [field: SerializeField] public AudioClip HalbertAttackClip { get; private set; }

        #endregion

        #endregion


        #region Methods

        public void ApllySettings()
        {
            Mixer.SetFloat(MusicAudioMixerGroupName, MusicVolume);
            Mixer.SetFloat(SFXAudioMixerGroupName, SFXVolume);
            Mixer.SetFloat(MenuAudioMixerGroupName, MenuVolume);
        }

        #endregion

    }
}