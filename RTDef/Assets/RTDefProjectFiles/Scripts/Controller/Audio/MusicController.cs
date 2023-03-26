using RTDef.Abstraction;
using RTDef.Data.Audio;
using UnityEngine;


namespace RTDef.Audio
{
    public sealed class MusicController
    {

        #region Fields

        private readonly SoundResources _soundResources;
        private readonly AudioSource _musicAudioSource;

        #endregion


        #region CodeLife

        public MusicController(IGameResources soundResources)
        {
            _soundResources = soundResources.SoundResources;
            _musicAudioSource = soundResources.MusicAudioSource;

            Play();
        }

        #endregion


        #region Methods

        private void Play()
        {
            _musicAudioSource.clip = _soundResources.MenuMusic;
            _musicAudioSource.Play();
        }

        #endregion

    }
}