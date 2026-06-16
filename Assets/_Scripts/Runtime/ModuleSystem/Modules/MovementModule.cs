using UnityEngine;

namespace ModuleSystem
{
    public class MovementModule : MonoBehaviour, IModule
    {
        private ModuleOwner _owner;
        public void Initialize(ModuleOwner owner)
        {
            this._owner = owner;

        }
    }
}

