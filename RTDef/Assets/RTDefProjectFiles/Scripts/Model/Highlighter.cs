using RTDef.Data;
using UnityEngine;


namespace RTDef.Model
{
    public sealed class Highlighter : MonoBehaviour
    {

        #region Fields

        private Outline _outline;
        [SerializeField] private HighlightConfig _config;

        #endregion


        #region Properties

        public bool Highlight
        {
            get => _outline.enabled;
            set => _outline.enabled = value;
        }


        #endregion


        #region Mono

        private void OnEnable()
        {
            if (_outline == null)
            {
                _outline = gameObject.AddComponent<Outline>();

                _outline.OutlineMode = _config.OutlineMode;
                _outline.OutlineColor = _config.OutlineColor;
                _outline.OutlineWidth = _config.OutlineWidth;

            }

            _outline.enabled = false;
        }

        #endregion

    }
}