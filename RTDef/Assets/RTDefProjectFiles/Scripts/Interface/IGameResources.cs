using RTDef.Data;
using RTDef.Data.Audio;
using UnityEngine;


namespace RTDef.Abstraction
{
    public interface IGameResources : IGame
    {
        AllScenes AllScenes { get; }
        SoundResources SoundResources { get; }
        AudioSource MenuAuidioSource { get; }
        AudioSource MusicAudioSource { get; }
    }
}