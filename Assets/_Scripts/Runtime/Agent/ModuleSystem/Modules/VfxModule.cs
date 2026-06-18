using Core.Effects;
using Core.Utilities;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    public class VfxModule : AbstractModule
    {
        //테스트 코드
        public GameObject dashEffectPrefab;
        public GameObject dashAttackEffectPrefab;

        private Dictionary<int, IPlayableVFX> _playableDict;

        protected override void OnInitialize()
        {
            _playableDict = GetComponentsInChildren<IPlayableVFX>()
                .ToDictionary(vfx => vfx.VfxName.AssetNameHash);
        }

        public void PlayVfx(int hash, Vector3 position, Quaternion rotation)
        {
            if (_playableDict.TryGetValue(hash, out var vfx))
            {
                vfx.PlayVFX(position, rotation);
            }
            else
            {
                DebugLogger.LogWarning($"VFX with hash : {hash} not found");
            }
        }

        public void PlayVfx(int hash)
        {
            if (_playableDict.TryGetValue(hash, out var vfx))
            {
                vfx.PlayVFX();
            }
            else
            {
                DebugLogger.LogWarning($"VFX with hash : {hash} not found");
            }
        }

        public void PlayDashVfx(Vector3 position, Quaternion rotation)
        {
            GameObject dashEffect = Instantiate(dashEffectPrefab, position, rotation);
            IPlayableVFX vfxCompo = dashEffect.GetComponent<IPlayableVFX>();
            vfxCompo.PlayVFX();
        }

        public void PlayDashAttackVfx(Vector3 position, Quaternion rotation)
        {
            GameObject dashAttackEffect = Instantiate(dashAttackEffectPrefab, position, rotation);
            IPlayableVFX vfxCompo = dashAttackEffect.GetComponent<IPlayableVFX>();
            vfxCompo.PlayVFX();
        }

        public void StopVfx(int hash)
        {
            if (_playableDict.TryGetValue(hash, out var vfx))
            {
                vfx.StopVFX();
            }
        }
    }
}