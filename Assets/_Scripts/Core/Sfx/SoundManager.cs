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

        private Dictionary<SfxType, SfxSO> sfxDict;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
        }

        public void Initialize()
        {
            sfxSource = GetComponent<AudioSource>();

            sfxDict = new Dictionary<SfxType, SfxSO>();
            foreach (var sfx in sfxClips)
            {
                if (sfx != null)
                    sfxDict[sfx.Type] = sfx;
            }
        }

        public void PlayEffect(SfxType sfxType)
        {
            if (sfxDict.TryGetValue(sfxType, out var sfxData))
            {
                sfxSource.PlayOneShot(sfxData.Clip, sfxData.Volume);
            }
            else
            {
                DebugLogger.LogWarning($"SFX [{sfxType}] not found in Dictionary!");
            }
        }
    }
}