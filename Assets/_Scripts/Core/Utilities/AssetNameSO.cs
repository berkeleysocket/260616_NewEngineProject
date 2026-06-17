using UnityEngine;

namespace Core.Utilities
{
    [CreateAssetMenu(fileName = "AssetNameSO", menuName = "SO/AssetNameSO", order = 0)]
    public class AssetNameSO : DescriptionSO
    {
        [field: SerializeField] public string AssetName { get; private set; }
        public int AssetNameHash { get; private set; }

        private void OnValidate()
        {
            this.AssetNameHash = Animator.StringToHash(AssetName);
        }
    }
}

