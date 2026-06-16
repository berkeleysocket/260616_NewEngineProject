using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModuleSystem
{
    public abstract class ModuleOwner : MonoBehaviour
    {
        private Dictionary<Type, IModule> _modules;

        private void Initialize()
        {
            _modules = new Dictionary<Type, IModule>();
            _modules = GetComponentsInChildren<IModule>()
                .ToDictionary(
                (module)=> module.GetType(),
                (module)=>module);
        }

        protected T GetModule<T>() where T : class, IModule
        {
            Type findModuleType = typeof(T); 
            T resultModule = null;

            _modules.TryGetValue(findModuleType, out IModule iModule);

            if (iModule != null)
                resultModule = iModule as T;

            return resultModule;
        }
    }
}