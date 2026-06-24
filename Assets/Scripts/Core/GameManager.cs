using Scripts.Core.InputSystem;
using Scripts.Core.ObjectPool;
using Scripts.Core.Sounds;
using Scripts.Core.Utilities;

namespace Scripts.Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public CreateManager CreateManager { get; private set; }
        public InputManager InputManager { get; private set; }
        public SoundManager SoundManager { get; private set; }

        protected override void OnAwake()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateManager = GetComponentInChildren<CreateManager>();
            InputManager = GetComponentInChildren<InputManager>();
            SoundManager = GetComponentInChildren<SoundManager>();
            CreateManager.Initialize();
            InputManager.Initialize();
            SoundManager.Initialize();
        }
    }
}