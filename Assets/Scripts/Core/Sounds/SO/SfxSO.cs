using UnityEngine;

namespace Scripts.Core.Sounds.SO
{

    [CreateAssetMenu(fileName = "SfxSO", menuName = "SO/Sfx")]
    public class SfxSO : ScriptableObject
    {
        [field: SerializeField] public SfxType Type { get; private set; }
        [field: SerializeField] public AudioClip Clip { get; private set; }

        [field: SerializeField][field: Range(0f, 1f)] public float Volume { get; private set; } = 1f;
    }
}