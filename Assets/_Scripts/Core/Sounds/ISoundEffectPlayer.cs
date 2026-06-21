namespace Core.Sounds
{
    public interface ISoundEffectPlayer : IInitializable
    {
        void PlayEffect(SfxType clip);
    }
}
