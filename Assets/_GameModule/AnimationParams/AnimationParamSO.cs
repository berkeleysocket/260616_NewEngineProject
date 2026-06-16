using Core.Utilities;
using UnityEngine;

namespace GameModules.AnimationParams
{
    public class AnimationParamSO : DescriptionSO
    {
        [field: SerializeField] public string ClipName { get; private set; }
        public int ClipHash { get; private set; }

        private void OnValidate()
        {
            this.ClipHash = Animator.StringToHash(ClipName);
        }
    }
}

