using UnityEngine;


namespace RTDef.Data
{
    [CreateAssetMenu(fileName = "HighlightConfig", menuName = "Data/HighlightConfig")]
    public sealed class HighlightConfig : ScriptableObject
    {

        #region Properties

        [field: SerializeField, Range(1, 4)] public int FactionID { get; private set; }
        [field: SerializeField] public Outline.Mode OutlineMode { get; private set; }
        [field: SerializeField] public Color OutlineColor { get; private set; }
        [field: SerializeField, Range(0.1f, 5.0f)] public float OutlineWidth { get; private set; }

        #endregion

    }
}