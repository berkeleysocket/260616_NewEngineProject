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

            DebugLogger.ValidateObject(_animator);
        }

        public void PlayClip(int stateNameHash, int animationLayer, float normalizedTime)
        {
            if(initialized)
                _animator.Play(stateNameHash, animationLayer, normalizedTime);
        }
    }
}
