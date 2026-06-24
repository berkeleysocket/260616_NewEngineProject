using UnityEngine;

namespace Scripts.Core.Utilities.SO
{
    public class DescriptionSO : ScriptableObject
    {
        [TextArea(5, 20)]
        [SerializeField] protected string m_Description;
    }
}

