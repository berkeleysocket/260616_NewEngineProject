using Core.Utilities;

using System.Collections.Generic;
using UnityEngine;

namespace Core.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour, ISoundEffectPlayer
    {
        public static SoundManager instance;

        [SerializeField] private SfxSO[] sfxClips;

        private AudioSource sfxSource;

        private Dictionary<SfxType, AudioClip> sfxDict;

        public void Initialize()
        {
            sfxSource = GetComponent<AudioSource>();

            sfxDict = new Dictionary<SfxType, AudioClip>();
            foreach(var sfx in sfxClips)
                sfxDict[sfx.Type] = sfx.Clip;
        }

        public void PlayEffect(SfxType sfxType)
        {
            if (sfxDict.TryGetValue(sfxType, out var clip))
                sfxSource.PlayOneShot(clip);
            else
                DebugLogger.LogWarning("SFX not found in Dictionary!");
        }

        public AudioSource GetEffectsSource()
        {
            throw new System.NotImplementedException();
        }
    }
}

