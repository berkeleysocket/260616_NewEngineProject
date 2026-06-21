using UnityEngine;

namespace Core.Sounds
{

    [CreateAssetMenu(fileName = "Sfx", menuName = "SO/SfxSO")]
    public class SfxSO : ScriptableObject
    {
        [field: SerializeField] public SfxType Type { get; private set; }
        [field: SerializeField] public AudioClip Clip { get; private set; }
    }
}