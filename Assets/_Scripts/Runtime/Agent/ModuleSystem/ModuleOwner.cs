using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    public abstract class ModuleOwner : MonoBehaviour
    {
        private Dictionary<Type, AbstractModule> _modules;

        private void Awake()
        {
            Initialize();
            DebugLogger.LogSuccess($"Initialize {gameObject.name}");
        }
        private void Initialize()
        {
            _modules = new Dictionary<Type, AbstractModule>();
            _modules = GetComponentsInChildren<AbstractModule>()
                .ToDictionary(
                (module)=> module.GetType(),
                (module)=>module);

            foreach(var module in _modules.Values)
                module.Initialize(this);

            OnInitialize();
        }

        protected abstract void OnInitialize();

        public T GetModule<T>() where T : AbstractModule
        {
            Type findModuleType = typeof(T); 
            T resultModule = null;

            _modules.TryGetValue(findModuleType, out AbstractModule iModule);

            if (iModule != null)
                resultModule = iModule as T;

            return resultModule;
        }
    }
}