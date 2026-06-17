namespace Runtime.Agents.ModuleSystem.Interface
{
    public interface IRenderer
    {
        void PlayClip(int stateNameHash, float transitionDuration, int animationLayer = 0, float normalizedTime = 0f);
    }
}
