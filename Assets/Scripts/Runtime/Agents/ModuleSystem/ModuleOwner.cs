using Scripts.Core.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem
{
    public abstract class ModuleOwner : MonoBehaviour
    {
        private Dictionary<Type, AbstractModule> _modules;

        private void Awake()
        {
            Initialize();
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
            if (_modules.TryGetValue(typeof(T), out AbstractModule iModule))
                return (T)iModule;

            AbstractModule module = _modules.Values.FirstOrDefault(moduleType => moduleType is T);
            if (module is T castModule)
                return castModule;

            return null;
        }
    }
}