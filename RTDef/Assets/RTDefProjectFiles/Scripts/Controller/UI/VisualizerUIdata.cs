using UnityEngine;


namespace RTDef.Data.UIColor
{
    [CreateAssetMenu(fileName = "VisualizerUIdata", menuName = "Data/VisualizerUIdata")]
    public sealed class VisualizerUIdata : ScriptableObject
    {

        #region Properties

        [field: SerializeField] public Color TextNormalColor { get; private set; }
        [field: SerializeField] public Color TextDisabledColor { get; private set; }

        [field: SerializeField] public Color NormalColor { get; private set; }
        [field: SerializeField] public Color HighlightedColor { get; private set; }
        [field: SerializeField] public Color PressedColor { get; private set; }
        [field: SerializeField] public Color DisabledColor { get; private set; }

        #endregion

    }
}