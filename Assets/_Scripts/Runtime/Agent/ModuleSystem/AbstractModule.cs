using Core.Utilities;
using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    public abstract class AbstractModule : MonoBehaviour
    {
        public bool initialized { get; protected set; }

        protected ModuleOwner owner;
        
        public virtual void Initialize(ModuleOwner owner)
        {
            this.owner = owner;
            this.initialized = true;

            DebugLogger.ValidateObject(owner);
            OnInitialize();
        }

        protected abstract void OnInitialize();
    }
}