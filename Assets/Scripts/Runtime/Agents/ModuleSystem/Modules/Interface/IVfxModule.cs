using Runtime.Agents.ModuleSystem;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.Interface
{
    public interface IVfxModule : IModule
    {
        void PlayVfx(int hash);
        void PlayVfx(int hash, Vector3 position, Quaternion rotation);
        void StopVfx(int hash);
    }
}