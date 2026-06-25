using Runtime.Agents.ModuleSystem;
using Scripts.Core.Utilities;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem
{
    public abstract class AbstractModule : MonoBehaviour
    {
        public bool initialized { get; protected set; }

        protected ModuleOwner owner;
        
        public virtual void Initialize(ModuleOwner owner)
        {
            this.owner = owner;
            this.initialized = true;

            DebugLogger.Assert(owner != null, "owner is null");
            OnInitialize();
        }

        protected abstract void OnInitialize();
    }
}