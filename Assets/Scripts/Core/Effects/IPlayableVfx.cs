using Scripts.Core.Utilities.SO;
using UnityEngine;

namespace Scripts.Core.Effects
{
    public interface IPlayableVfx
    {
        AssetNameSO VfxName { get; }
        float VfxDuration { get; }
        void PlayVFX(Vector3 position, Quaternion rotation);
        void PlayVFX();
        void StopVFX();
    }
}