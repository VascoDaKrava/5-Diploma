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


        #region Methods

        public void SetResourcesQuantity(int food, int wood)
        {
            _foodText.text = $"{food}";
            _woodText.text = $"{wood}";
        }

        #endregion

    }
}