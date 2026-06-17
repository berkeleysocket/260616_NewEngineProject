using Core.Utilities;
using UnityEngine;

namespace Core.Effects
{
    public interface IPlayableVFX
    {
        AssetNameSO VfxName { get; }
        void PlayVFX(Vector3 position, Quaternion rotation);
        void PlayVFX();
        void StopVFX();
    }
}