using Core.Utilities;
using UnityEngine;

namespace GameModules.AnimationParams
{
    [CreateAssetMenu(fileName = "AnimationParameterSO", menuName = "SO/AnimationParameterSO", order = 0)]
    public class AnimationParameterSO : DescriptionSO
    {
        [field: SerializeField] public string ClipName { get; private set; }
        public int ClipHash { get; private set; }

        private void OnValidate()
        {
            this.ClipHash = Animator.StringToHash(ClipName);
        }
    }
}

