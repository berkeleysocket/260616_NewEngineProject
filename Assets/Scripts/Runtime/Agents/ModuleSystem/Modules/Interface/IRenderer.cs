using Runtime.Agents.ModuleSystem;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.Interface
{
    public interface IRenderer : IModule
    {
        void PlayClip(int stateNameHash, float transitionDuration, int animationLayer = 0, float normalizedTime = 0f);
    }
}
