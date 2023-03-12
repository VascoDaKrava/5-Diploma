using RTDef.Abstraction;
using System;


namespace RTDef.Menu
{
    public sealed class LoginPanelController : IDisposable
    {

        #region Fields

        private const string LOGIN_LABLE = "LOGIN";
        private const string REGISTER_LABLE = "REGISTER";

        private readonly StartPanelView _startPanel;
        private readonly LoginPanelView _loginPanel;
        private readonly InfoPanelController _infoPanel;

        #endregion


        #region CodeLife

        public LoginPanelController(IMainMenuPanels mainMenuPanels, InfoPanelController infoPanel)
        {
            _startPanel = mainMenuPanels.StartPanel;
            _loginPanel = mainMenuPanels.LoginPanel;
            _infoPanel = infoPanel;
            
            _loginPanel.OnEnableEvent += LoginPanelOnEnableHandler;
            _loginPanel.ExitButton.onClick.AddListener(OnExitClickHandler);
            _loginPanel.RegistrationToggle.onValueChanged.AddListener(OnRegistrationToggleValueChangedHandler);
            _loginPanel.ActionButton.onClick.AddListener(OnActionButtonClickHandler);
        }

        public void Dispose()
        {
            _loginPanel.OnEnableEvent -= LoginPanelOnEnableHandler;
            _loginPanel.ExitButton.onClick.RemoveListener(OnExitClickHandler);
            _loginPanel.RegistrationToggle.onValueChanged.RemoveListener(OnRegistrationToggleValueChangedHandler);
            _loginPanel.ActionButton.onClick.RemoveListener(OnActionButtonClickHandler);
        }

        #endregion


        #region Methods

        private void OnActionButtonClickHandler()
        {
            if (!CheckInput())
            {
                return;
            }

            if (_loginPanel.RegistrationToggle.isOn)
            {
                _infoPanel.ShowSuccess($"Reg {_loginPanel.LoginInputField.text} / {_loginPanel.PasswordInputField.text} / {_loginPanel.EmailInputField.text}");
            }
            else
            {
                _infoPanel.ShowSuccess($"Login {_loginPanel.LoginInputField.text} / {_loginPanel.PasswordInputField.text}");
            }
        }

        private void OnRegistrationToggleValueChangedHandler(bool state)
        {
            _loginPanel.EmailInputField.gameObject.SetActive(state);
            _loginPanel.ActionButtonText.text = state ? REGISTER_LABLE : LOGIN_LABLE;
        }

        private void LoginPanelOnEnableHandler()
        {
            _loginPanel.RegistrationToggle.isOn = false;
            _loginPanel.EmailInputField.gameObject.SetActive(false);
            _loginPanel.ActionButtonText.text = LOGIN_LABLE;
        }

        private void OnExitClickHandler()
        {
            _loginPanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
        }

        /// <summary>
        /// Check input fields for correct data
        /// </summary>
        /// <returns>True if all is OK. False if something wrong</returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(_loginPanel.LoginInputField.text))
            {
                _infoPanel.ShowError("Login incorrect!");
                return false;
            }

            if (string.IsNullOrEmpty(_loginPanel.PasswordInputField.text))
            {
                _infoPanel.ShowError("Password incorrect!");
                return false;
            }

            if (string.IsNullOrEmpty(_loginPanel.EmailInputField.text) && _loginPanel.RegistrationToggle.isOn)
            {
                _infoPanel.ShowError("Email incorrect!");
                return false;
            }

            return true;
        }

        #endregion

    }
}