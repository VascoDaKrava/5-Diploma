using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace RTDef.Data.Audio
{
	[CreateAssetMenu(fileName = "AudioResorces", menuName = "Data/AudioResorces")]
	public sealed class SoundResources : ScriptableObject
	{

        #region Properties

        [field: SerializeField] public float MusicVolume { get; set; }
        [field: SerializeField] public float SFXVolume { get; set; }
        [field: SerializeField] public float MenuVolume { get; set; }
		
        [field: SerializeField] public AudioMixer Mixer { get; private set; }
        [field: SerializeField] public string MasterAudioMixerGroupName { get; private set; }
        [field: SerializeField] public string MusicAudioMixerGroupName { get; private set; }
        [field: SerializeField] public string SFXAudioMixerGroupName { get; private set; }
        [field: SerializeField] public string MenuAudioMixerGroupName { get; private set; }

        [field: SerializeField] public AudioClip MenuMusic { get; private set; }

        [field: SerializeField] public List<AudioClip> BackgroundMusic { get; private set; }

        [field: SerializeField] public AudioClip ButtonSelectClip { get; private set; }
        [field: SerializeField] public AudioClip ButtonClickClip { get; private set; }

        #endregion

    }
}