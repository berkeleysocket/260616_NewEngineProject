using Runtime.Agents.ModuleSystem;
using Scripts.Core.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem
{
    public abstract class ModuleOwner : MonoBehaviour
    {
        private Dictionary<Type, IModule> _modules;

        private void Awake()
        {
            Initialize();
        }
        private void Initialize()
        {
            _modules = new Dictionary<Type, IModule>();
            _modules = GetComponentsInChildren<IModule>()
                .ToDictionary(
                (module)=> module.GetType(),
                (module)=>module);

            foreach(IModule module in _modules.Values)
                module.Initialize(this);

            OnInitialize();
        }

        protected abstract void OnInitialize();

        public T GetModule<T>() where T : class, IModule
        {
            if (_modules.TryGetValue(typeof(T), out IModule iModule))
                return (T)iModule;

            IModule module = _modules.Values.FirstOrDefault(moduleType => moduleType is T);
            if (module is T castModule)
                return castModule;

            return null;
        }
    }
}