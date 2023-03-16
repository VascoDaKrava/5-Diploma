using RTDef.Data.UIColor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RTDef.UI
{
    public sealed class ButtonVisualizer : MonoBehaviour
    {

        #region Fields

        [SerializeField] private PointerEvents _button;
        [SerializeField] private Image _buttonImage;
        [SerializeField] private TMP_Text _buttonLable;
        [SerializeField] private VisualizerUIdata _visualizerUIdata;

        #endregion


        #region Mono

        private void OnEnable()
        {
            _button.OnPointerDownEvent += OnPointerDownEventHandler;
            _button.OnPointerUpEvent += OnPointerUpEventHandler;
            _button.OnPointerEnterEvent += OnPointerEnterEventHandler;
            _button.OnPointerExitEvent += OnPointerExitEventHandler;
            _button.OnInteractableSetEvent += OnInteractableSetEventHandler;
        }

        private void OnDisable()
        {
            _button.OnPointerDownEvent -= OnPointerDownEventHandler;
            _button.OnPointerUpEvent -= OnPointerUpEventHandler;
            _button.OnPointerEnterEvent -= OnPointerEnterEventHandler;
            _button.OnPointerExitEvent -= OnPointerExitEventHandler;
            _button.OnInteractableSetEvent -= OnInteractableSetEventHandler;
        }

        #endregion


        #region Methods

        private void OnInteractableSetEventHandler(bool state)
        {
            _buttonImage.color = state ? _visualizerUIdata.NormalColor : _visualizerUIdata.DisabledColor;
            _buttonLable.color = state ? _visualizerUIdata.TextNormalColor : _visualizerUIdata.TextDisabledColor;
        }

        private void OnPointerExitEventHandler()
        {
            _buttonImage.color = _visualizerUIdata.NormalColor;
        }

        private void OnPointerEnterEventHandler()
        {
            _buttonImage.color = _visualizerUIdata.HighlightedColor;
        }

        private void OnPointerUpEventHandler()
        {
            _buttonImage.color = _visualizerUIdata.NormalColor;
        }

        private void OnPointerDownEventHandler()
        {
            _buttonImage.color = _visualizerUIdata.PressedColor;
        }

        #endregion

    }
}