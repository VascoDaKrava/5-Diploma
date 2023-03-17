using RTDef.Data.Audio;
using System;


namespace RTDef.Menu
{
    public sealed class OptionsPanelController : IDisposable
    {

        #region Fields

        private readonly StartPanelView _startPanel;
        private readonly OptionsPanelView _optionsPanel;
        private readonly SoundResources _soundResources;

        #endregion


        #region CodeLife

        public OptionsPanelController(StartPanelView startPanel, OptionsPanelView optionsPanel, SoundResources soundResources)
        {
            _startPanel = startPanel;
            _optionsPanel = optionsPanel;
            _soundResources = soundResources;

            _optionsPanel.OnEnableEvent += OptionsPanelOnEnableHandler;
            _optionsPanel.ExitButton.OnPointerClickEvent += OnExitClickHandler;
            _optionsPanel.MenuVolumeSlider.onValueChanged.AddListener(OnMenuVolumeChangeHandler);
            _optionsPanel.SFXVolumeSlider.onValueChanged.AddListener(OnSFXVolumeSliderChangeHandler);
            _optionsPanel.MusicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderChangeHandler);
        }

        public void Dispose()
        {
            _optionsPanel.OnEnableEvent -= OptionsPanelOnEnableHandler;
            _optionsPanel.ExitButton.OnPointerClickEvent -= OnExitClickHandler;
            _optionsPanel.MenuVolumeSlider.onValueChanged.RemoveListener(OnMenuVolumeChangeHandler);
            _optionsPanel.SFXVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeSliderChangeHandler);
            _optionsPanel.MusicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeSliderChangeHandler);
        }

        #endregion


        #region Methods

        public void UpdateSlidersPosition()
        {
            _optionsPanel.MenuVolumeSlider.value = _soundResources.MenuVolume.dBtoFloat();
            _optionsPanel.SFXVolumeSlider.value = _soundResources.SFXVolume.dBtoFloat();
            _optionsPanel.MusicVolumeSlider.value = _soundResources.MusicVolume.dBtoFloat();
        }

        private void OptionsPanelOnEnableHandler()
        {
            UpdateSlidersPosition();
        }

        private void OnExitClickHandler()
        {
            _optionsPanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
        }

        private void OnMenuVolumeChangeHandler(float value)
        {
            _soundResources.MenuVolume = value.dB();
            _soundResources.Mixer.SetFloat(_soundResources.MenuAudioMixerGroupName, value.dB());
        }

        private void OnSFXVolumeSliderChangeHandler(float value)
        {
            _soundResources.SFXVolume = value.dB();
            _soundResources.Mixer.SetFloat(_soundResources.SFXAudioMixerGroupName, value.dB());
        }

        private void OnMusicVolumeSliderChangeHandler(float value)
        {
            _soundResources.MusicVolume = value.dB();
            _soundResources.Mixer.SetFloat(_soundResources.MusicAudioMixerGroupName, value.dB());
        }

        #endregion

    }
}