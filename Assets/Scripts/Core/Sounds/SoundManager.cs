using Scripts.Core.Utilities;
using Scripts.Core.Sounds.SO;

using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Core.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
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