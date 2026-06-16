using UnityEngine;

namespace Core.Utilities
{
    public class DescriptionSO : ScriptableObject
    {
        [TextArea(5, 20)]
        [SerializeField] protected string m_Description;
    }
}

