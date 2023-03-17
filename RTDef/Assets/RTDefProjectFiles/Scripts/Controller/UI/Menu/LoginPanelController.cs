using RTDef.Abstraction;
using RTDef.PlayFab;
using System;


namespace RTDef.Menu
{
    public sealed class LoginPanelController : IDisposable
    {

        #region Fields

        private const string LOGIN_BTN_LABLE = "LOGIN";
        private const string REGISTER_BTN_LABLE = "REGISTER";
        private const string LOGOUT_BTN_LABLE = "LOGOUT";

        private const string LOGIN_INCORRECT = "Login incorrect!";
        private const string PASSWORD_INCORRECT = "Password incorrect!";
        private const string EMAIL_INCORRECT = "Email incorrect!";

        private readonly StartPanelView _startPanel;
        private readonly LoginPanelView _loginPanel;
        private readonly InfoPanelController _infoPanel;
        private readonly DataServerConnector _dataServer;

        #endregion


        #region Properties

        public bool IsClientLoggedIn => _dataServer.IsClientLoggedIn;
        public string ClientUserName => _dataServer.ClientUserName;

        #endregion


        #region CodeLife

        public LoginPanelController(IMainMenuPanels mainMenuPanels, InfoPanelController infoPanel)
        {
            _startPanel = mainMenuPanels.StartPanel;
            _loginPanel = mainMenuPanels.LoginPanel;
            _infoPanel = infoPanel;

            _dataServer = new DataServerConnector(_infoPanel);

            _loginPanel.OnEnableEvent += LoginPanelOnEnableHandler;
            _loginPanel.ExitButton.OnPointerClickEvent += OnExitClickHandler;
            _loginPanel.RegistrationToggle.onValueChanged.AddListener(OnRegistrationToggleValueChangedHandler);
            _loginPanel.ActionButton.OnPointerClickEvent += OnActionButtonClickHandler;

            _dataServer.OnLoginSuccess += OnDataServerLoginSuccessHandler;
        }

        public void Dispose()
        {
            _loginPanel.OnEnableEvent -= LoginPanelOnEnableHandler;
            _loginPanel.ExitButton.OnPointerClickEvent -= OnExitClickHandler;
            _loginPanel.RegistrationToggle.onValueChanged.RemoveListener(OnRegistrationToggleValueChangedHandler);
            _loginPanel.ActionButton.OnPointerClickEvent -= OnActionButtonClickHandler;

            _dataServer.OnLoginSuccess -= OnDataServerLoginSuccessHandler;
        }

        #endregion


        #region Methods

        private void OnDataServerLoginSuccessHandler()
        {
            SetInteractions(IsClientLoggedIn);
        }

        private void OnActionButtonClickHandler()
        {
            if (IsClientLoggedIn)
            {
                _dataServer.Logout();
                _loginPanel.gameObject.SetActive(false);
                _loginPanel.gameObject.SetActive(true);
                return;
            }

            if (!CheckInput())
            {
                return;
            }

            if (_loginPanel.RegistrationToggle.isOn)
            {
                _dataServer.Register(_loginPanel.LoginInputField.text, _loginPanel.PasswordInputField.text, _loginPanel.EmailInputField.text);
            }
            else
            {
                _dataServer.Login(_loginPanel.LoginInputField.text, _loginPanel.PasswordInputField.text);
            }
        }

        private void OnRegistrationToggleValueChangedHandler(bool state)
        {
            _loginPanel.EmailInputField.gameObject.SetActive(state);
            _loginPanel.ActionButtonText.text = state ? REGISTER_BTN_LABLE : LOGIN_BTN_LABLE;
        }

        private void LoginPanelOnEnableHandler()
        {
            SetInteractions(IsClientLoggedIn);
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
                _infoPanel.ShowError(LOGIN_INCORRECT);
                return false;
            }

            if (string.IsNullOrEmpty(_loginPanel.PasswordInputField.text))
            {
                _infoPanel.ShowError(PASSWORD_INCORRECT);
                return false;
            }

            if (string.IsNullOrEmpty(_loginPanel.EmailInputField.text) && _loginPanel.RegistrationToggle.isOn)
            {
                _infoPanel.ShowError(EMAIL_INCORRECT);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Set UI elements state
        /// </summary>
        /// <param name="isLoggedin">Is loggedin</param>
        private void SetInteractions(bool isLoggedin)
        {
            _loginPanel.RegistrationToggle.interactable = !isLoggedin;
            _loginPanel.LoginInputField.interactable = !isLoggedin;
            _loginPanel.PasswordInputField.interactable = !isLoggedin;
            _loginPanel.EmailInputField.interactable = !isLoggedin;

            if (isLoggedin)
            {
                _loginPanel.ActionButtonText.text = LOGOUT_BTN_LABLE;
            }
            else
            {
                OnRegistrationToggleValueChangedHandler(_loginPanel.RegistrationToggle.isOn);
            }
        }

        #endregion

    }
}