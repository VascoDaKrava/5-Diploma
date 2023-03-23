using TMPro;
using UnityEngine;


namespace RTDef.Menu
{
    public sealed class InfoPanelView : MonoBehaviour
    {

        #region Properties

        [field: SerializeField] public TextMeshProUGUI Title { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Message { get; private set; }

        #endregion

    }
}