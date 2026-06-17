using Core.Utilities;
using GameModules.InputActions;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.InputSystem
{
    public class InputManager : MonoSingleton<InputManager>
    {
        [SerializeField] private InputReaderBaseSO[] readerRegistry;
        private Dictionary<Type, InputReaderBaseSO> _readers;
        private Dictionary<Type, bool> _isReaderRegistered;
        private CharacterInputActions _inputActions;

        private void Awake()
        {
            TestInitialize();
        }

        private void OnDisable()
        {
            DisableAllReader();
        }

        private void OnApplicationQuit()
        {
            DisableAllReader();
        }

        public void Initialize()
        {
            _inputActions = new CharacterInputActions();
            _readers = new Dictionary<Type, InputReaderBaseSO>();
            _isReaderRegistered = new Dictionary<Type, bool>();

            foreach (InputReaderBaseSO reader in readerRegistry)
            {
                Type key = reader.GetType();
                _readers[key] = reader;
                _isReaderRegistered[key] = false;

                reader.Initialize(_inputActions);
            }

            DebugLogger.Assert(readerRegistry != null && readerRegistry.Length > 0, "ReaderRegistry is null");
        }

        private void TestInitialize()
        {
            Initialize();
            DebugLogger.LogSuccess("Initialize InputManager");
            EnableReader<CharacterInputReader>();
            DebugLogger.LogSuccess("Enable CharacterInputReader");
        }

        public void EnableReader<T>() where T : InputReaderBaseSO
        {
            if (_readers != null && _readers.Count != 0)
            {
                Type key = typeof(T);
                _readers.TryGetValue(key, out InputReaderBaseSO reader);
                _isReaderRegistered.TryGetValue(key, out bool isRegistered);

                if (!isRegistered)
                {
                    reader.Enable();
                    _isReaderRegistered[key] = true;
                }
            }
        }

        public void DisableReader<T>() where T : InputReaderBaseSO
        {
            if (_readers != null && _readers.Count != 0)
            {
                Type key = typeof(T);
                _readers.TryGetValue(key, out InputReaderBaseSO reader);
                _isReaderRegistered.TryGetValue(key, out bool isRegistered);

                if(isRegistered)
                {
                    reader.Disable();
                    _isReaderRegistered[key] = false;
                }
            }
        }

        public void EnableAllReader()
        {
            if (_readers != null && _readers.Count != 0)
            {
                foreach (InputReaderBaseSO reader in _readers.Values)
                {
                    Type key = reader.GetType();
                    reader.Enable();
                    _isReaderRegistered[key] = true;
                }
            }
        }

        public void DisableAllReader()
        {
            if (_readers != null && _readers.Count != 0)
            {
                foreach (InputReaderBaseSO reader in _readers.Values)
                {
                    Type key = reader.GetType();
                    reader.Disable();
                    _isReaderRegistered[key] = false;
                }
            }
        }
    }
}