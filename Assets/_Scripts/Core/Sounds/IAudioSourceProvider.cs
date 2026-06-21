using UnityEngine;

public interface IAudioSourceProvider
{
    AudioSource GetEffectsSource();
    AudioSource GetMusicSource();
}