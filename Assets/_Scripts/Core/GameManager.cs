using Core.InputSystem;
using Core.ObjectPool;
using Core.Sounds;
using Core.Utilities;

using UnityEngine;

namespace Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public static GameManager Instance 
        { 
            get
            {
                if(_instance == null)
                {
                    GameObject go = new GameObject();
                    GameManager instance = go.AddComponent<GameManager>();
                    go.name = typeof(GameManager).Name;
                    _instance = instance;
                }

                return _instance;
            }
        }

        public static GameManager _instance;
        public CreateManager CreateManager { get; private set; }
        public InputManager InputManager { get; private set; }
        public ISoundEffectPlayer SoundManager { get; private set; }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateManager = GetComponentInChildren<CreateManager>();
            InputManager = GetComponentInChildren<InputManager>();
            SoundManager = GetComponentInChildren<ISoundEffectPlayer>();
            CreateManager.Initialize();
            InputManager.Initialize();
            SoundManager.Initialize();
        }
    }
}