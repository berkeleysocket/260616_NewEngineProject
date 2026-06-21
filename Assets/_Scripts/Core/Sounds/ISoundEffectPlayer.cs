using UnityEngine;

public interface ISoundEffectPlayer
{
    void PlayEffect(AudioClip clip);
    void PlayEffectRandomized(params AudioClip[] clips);
}