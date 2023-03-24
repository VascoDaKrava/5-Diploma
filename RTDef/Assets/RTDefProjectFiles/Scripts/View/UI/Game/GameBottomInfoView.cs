using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RTDef.Game.UI
{
    public sealed class GameBottomInfoView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Image _titleImage;
        [SerializeField] private TMP_Text _titleText;

        [SerializeField] private Slider _lifeSlider;
        [SerializeField] private TMP_Text _lifeText;

        [SerializeField] private TMP_Text _attackText;
        [SerializeField] private TMP_Text _defenceText;
        [SerializeField] private TMP_Text _rangeText;

        [SerializeField] private Sprite _melleeAttackSprite;
        [SerializeField] private Sprite _rangeAttackSprite;
        [SerializeField] private Image _attackImage;

        [SerializeField] private RectTransform _rangeGroup;

        #endregion


        #region Methods

        public void SetTitle(Sprite image, string title, int currentLife, int maxLife)
        {
            _titleImage.sprite = image;
            _titleText.text = title;

            SetLife(currentLife, maxLife);
        }

        public void SetLife(int currentLife, int maxLife)
        {
            _lifeSlider.value = currentLife;
            _lifeSlider.maxValue = maxLife;

            _lifeText.text = $"{currentLife}/{maxLife}";
        }

        public void SetCharacteristics(int attack, int defence)
        {
            _attackImage.sprite = _melleeAttackSprite;
            _attackText.text = $"{attack}";
            _defenceText.text = $"{defence}";

            _rangeGroup.gameObject.SetActive(false);
        }

        public void SetCharacteristics(int attack, int defence, int range)
        {
            SetCharacteristics(attack, defence);
            _attackImage.sprite = _rangeAttackSprite;

            _rangeText.text = $"{range}";

            _rangeGroup.gameObject.SetActive(true);
        }

        #endregion

    }
}