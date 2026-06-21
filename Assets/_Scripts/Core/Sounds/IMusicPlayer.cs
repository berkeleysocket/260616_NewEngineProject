using UnityEngine;

public interface IMusicPlayer
{
    void PlayMusic(AudioClip clip, bool loop = true);
    void StopMusic();
    void SetMusicVolume(float volume);
}
