using RTDef.Abstraction;
using RTDef.UI;
using TMPro;
using UnityEngine;


namespace RTDef.Game.UI
{
    public sealed class GameTopPanelView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private TMP_Text _foodText;
        [SerializeField] private TMP_Text _woodText;

        #endregion


        #region Properties

        [field: SerializeField] public CustomPointerEvent MenuButton { get; private set; }

        #endregion


        #region Methods

        public void SetResourcesQuantity(IHarvestingResources resources)
        {
            _foodText.text = resources.Food < 1000 ? $"{resources.Food}" : $"{resources.Food:### ### ###}";
            _woodText.text = resources.Wood < 1000 ? $"{resources.Wood}" : $"{resources.Wood:### ### ###}";
        }

        #endregion

    }
}