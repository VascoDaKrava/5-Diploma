using TMPro;
using UnityEngine;


namespace RTDef.Game.UI
{
    public sealed class TopPanelView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private TMP_Text _foodText;
        [SerializeField] private TMP_Text _woodText;

        #endregion


        #region Metods

        public void SetResourcesQuantity(int food, int wood)
        {
            _foodText.text = $"{food}";
            _woodText.text = $"{wood}";
        }

        #endregion

    }
}