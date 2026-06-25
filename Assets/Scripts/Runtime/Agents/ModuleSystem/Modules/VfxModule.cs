using Scripts.Core.Effects;
using Scripts.Core.Utilities;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules
{
    public class VfxModule : AbstractModule, IVfxModule
    {
        private Dictionary<int, IPlayableVfx> _playableDict;

        protected override void OnInitialize()
        {
            _playableDict = GetComponentsInChildren<IPlayableVfx>()
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

        public void StopVfx(int hash)
        {
            if (_playableDict.TryGetValue(hash, out var vfx))
            {
                vfx.StopVFX();
            }
        }
    }
}