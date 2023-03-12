using RTDef.Data.Audio;
using RTDef.UI;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Audio
{
    public sealed class MenuSoundFXController : IDisposable
    {

        #region Fields

        private List<PointerEvents> _buttons = new List<PointerEvents>();
        private readonly SoundResources _soundResources;
        private readonly AudioSource _mainSource;

        #endregion


        #region CodeLife

        public MenuSoundFXController(Transform root, SoundResources soundResources, AudioSource mainSource)
        {
            _buttons.AddRange(root.gameObject.GetComponentsInChildren<PointerEvents>(true));

            foreach (var button in _buttons)
            {
                button.OnPointerEnterEvent += OnPointerEnter;
                button.OnPointerClickEvent += OnClick;
            }

            _soundResources = soundResources;
            _mainSource = mainSource;
        }

        public void Dispose()
        {
            foreach (var button in _buttons)
            {
                button.OnPointerEnterEvent -= OnPointerEnter;
                button.OnPointerClickEvent -= OnClick;
            }
        }

        #endregion


        #region Methods

        private void OnPointerEnter()
        {
            _mainSource.clip = _soundResources.ButtonSelectClip;
            _mainSource.Play();
        }

        private void OnClick()
        {
            _mainSource.clip = _soundResources.ButtonClickClip;
            _mainSource.Play();
        }

        #endregion

    }
}