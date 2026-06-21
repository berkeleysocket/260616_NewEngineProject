using Core.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        //[SerializeField] private AudioClip[] bgmClips;
        [SerializeField] private AudioClip[] sfxClips;

        //[SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource sfxSource;

        //private Dictionary<EBgm, AudioClip> bgmDict;
        private Dictionary<SfxType, AudioClip> sfxDict;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            InitDictionaries();
        }

        private void InitDictionaries()
        {
            //bgmDict = new Dictionary<EBgm, AudioClip>();
            //for (int i = 0; i < bgmClips.Length; i++)
            //{
            //    bgmDict[(EBgm)i] = bgmClips[i];
            //}

            sfxDict = new Dictionary<SfxType, AudioClip>();
            for (int i = 0; i < sfxClips.Length; i++)
            {
                sfxDict[(SfxType)i] = sfxClips[i];
            }
        }

        //public void PlayBGM(SfxType bgmType)
        //{
        //    if (bgmDict.TryGetValue(bgmType, out var clip))
        //    {
        //        bgmSource.clip = clip;
        //        bgmSource.loop = true;
        //        bgmSource.Play();
        //    }
        //    else
        //    {
        //        DebugLogger.LogWarning("BGM not found in Dictionary!");
        //    }
        //}

        public void PlaySFX(SfxType sfxType)
        {
            if (sfxDict.TryGetValue(sfxType, out var clip))
            {
                sfxSource.PlayOneShot(clip);
            }
            else
            {
                DebugLogger.LogWarning("SFX not found in Dictionary!");
            }
        }
    }
}

