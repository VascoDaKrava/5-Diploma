using RTDef.Abstraction;
using RTDef.UI;
using TMPro;
using Unity.VisualScripting;
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

        public void SetResourcesQuantity(IGameGathering gathering)
        {
            _foodText.text = gathering.Food < 1000 ? $"{gathering.Food}" : $"{gathering.Food:### ### ###}";
            _woodText.text = gathering.Wood < 1000 ? $"{gathering.Wood}" : $"{gathering.Wood:### ### ###}";
        }

        #endregion

    }
}