using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules
{
    [RequireComponent(typeof(Animator))]
    public class RendererModule : AbstractModule, IRenderer
    {
        private Animator _animator;

        protected override void OnInitialize()
        {
            this._animator = GetComponent<Animator>();
        }

        public void PlayClip(int stateNameHash, float transitionDuration, int animationLayer = 0, float normalizedTime = 0f)
        {
            if (initialized)
                _animator.CrossFadeInFixedTime(stateNameHash, transitionDuration, animationLayer, normalizedTime);
        }
    }
}
