namespace Runtime.Agents.ModuleSystem.Interface
{
    public interface IRenderer
    {
        void PlayClip(int stateNameHash, int animationLayer, float normalizedTime);
    }
}
