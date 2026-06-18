using Core.ObjectPool;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class SystemManager : MonoBehaviour
    {
        public static SystemManager Instance 
        { 
            get
            {
                if(_instance == null)
                {
                    GameObject go = new GameObject();
                    SystemManager instance = go.AddComponent<SystemManager>();
                    go.name = typeof(SystemManager).Name;
                    _instance = instance;
                }

                return _instance;
            }
        }
        public static SystemManager _instance;
        public CreateManager CreateManager { get; private set; }

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
            CreateManager.Initialize();
        }
    }
}