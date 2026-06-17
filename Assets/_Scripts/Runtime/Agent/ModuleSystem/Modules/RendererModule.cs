using Core.Utilities;
using Runtime.Agents.ModuleSystem.Interface;
using UnityEngine;

namespace Runtime.Agents.ModuleSystem
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
