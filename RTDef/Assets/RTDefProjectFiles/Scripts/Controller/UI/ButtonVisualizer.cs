using RTDef.Data.UIColor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RTDef.UI
{
    public sealed class ButtonVisualizer : MonoBehaviour
    {

        #region Fields

        [SerializeField] private CustomPointerEvent _button;
        [SerializeField] private Image _buttonImage;
        [SerializeField] private TMP_Text _buttonLabel;
        [SerializeField] private VisualizerUIdata _visualizerUIdata;

        private bool _hasImage;
        private bool _hasText;

        #endregion


        #region Mono

        private void Awake()
        {
            _hasText = _buttonLabel;
            _hasImage = _buttonImage;

            _button.OnPointerDownEvent += OnPointerDownEventHandler;
            _button.OnPointerUpEvent += OnPointerUpEventHandler;
            _button.OnPointerEnterEvent += OnPointerEnterEventHandler;
            _button.OnPointerExitEvent += OnPointerExitEventHandler;
            _button.OnInteractableSetEvent += OnInteractableSetEventHandler;
        }

        private void OnDestroy()
        {
            _button.OnPointerDownEvent -= OnPointerDownEventHandler;
            _button.OnPointerUpEvent -= OnPointerUpEventHandler;
            _button.OnPointerEnterEvent -= OnPointerEnterEventHandler;
            _button.OnPointerExitEvent -= OnPointerExitEventHandler;
            _button.OnInteractableSetEvent -= OnInteractableSetEventHandler;
        }

        #endregion


        #region Methods

        public void SetHighlight()
        {
            TrySetImageColor(_visualizerUIdata.HighlightedColor);
        }

        private void OnInteractableSetEventHandler(bool state)
        {
            TrySetImageColor(state ? _visualizerUIdata.NormalColor : _visualizerUIdata.DisabledColor);
            TrySetTextColor(state ? _visualizerUIdata.TextNormalColor : _visualizerUIdata.TextDisabledColor);
        }

        private void OnPointerExitEventHandler() => TrySetImageColor(_visualizerUIdata.NormalColor);

        private void OnPointerEnterEventHandler() => TrySetImageColor(_visualizerUIdata.HighlightedColor);

        private void OnPointerUpEventHandler() => TrySetImageColor(_visualizerUIdata.NormalColor);

        private void OnPointerDownEventHandler() => TrySetImageColor(_visualizerUIdata.PressedColor);

        private void TrySetImageColor(Color color)
        {
            if (_hasImage)
            {
                _buttonImage.color = color;
            }
        }

        private void TrySetTextColor(Color color)
        {
            if (_hasText)
            {
                _buttonLabel.color = color;
            }
        }

        #endregion

    }
}