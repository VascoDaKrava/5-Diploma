using RTDef.Abstraction;
using RTDef.PlayFab;
using System;


namespace RTDef.Menu
{
    public sealed class ProfilePanelController : IDisposable
    {

        #region Fields

        private const string LOGIN_BTN_LABLE = "LOGIN";
        private const string REGISTER_BTN_LABLE = "REGISTER";
        private const string LOGOUT_BTN_LABLE = "LOGOUT";

        private const string LOGIN_INCORRECT = "Login incorrect!";
        private const string PASSWORD_INCORRECT = "Password incorrect!";
        private const string EMAIL_INCORRECT = "Email incorrect!";

        private readonly StartPanelView _startPanel;
        private readonly ProfilePanelView _profilePanel;
        private readonly InfoPanelController _infoPanel;
        private readonly DataServerConnector _dataServer;

        #endregion


        #region Properties

        public bool IsClientLoggedIn => _dataServer.IsClientLoggedIn;
        public string ClientUserName => _dataServer.ClientUserName;

        #endregion


        #region CodeLife

        public ProfilePanelController(IMainMenuPanels mainMenuPanels, InfoPanelController infoPanel)
        {
            _startPanel = mainMenuPanels.StartPanel;
            _profilePanel = mainMenuPanels.ProfilePanel;
            _infoPanel = infoPanel;

            _dataServer = new DataServerConnector(_infoPanel);

            _profilePanel.OnEnableEvent += ProfilePanelOnEnableHandler;
            _profilePanel.ExitButton.OnPointerClickEvent += OnExitClickHandler;
            _profilePanel.RegistrationToggle.onValueChanged.AddListener(OnRegistrationToggleValueChangedHandler);
            _profilePanel.ActionButton.OnPointerClickEvent += OnActionButtonClickHandler;

            _dataServer.OnLoginSuccess += OnDataServerLoginSuccessHandler;
        }

        public void Dispose()
        {
            _profilePanel.OnEnableEvent -= ProfilePanelOnEnableHandler;
            _profilePanel.ExitButton.OnPointerClickEvent -= OnExitClickHandler;
            _profilePanel.RegistrationToggle.onValueChanged.RemoveListener(OnRegistrationToggleValueChangedHandler);
            _profilePanel.ActionButton.OnPointerClickEvent -= OnActionButtonClickHandler;

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
                _profilePanel.gameObject.SetActive(false);
                _profilePanel.gameObject.SetActive(true);
                return;
            }

            if (!CheckInput())
            {
                return;
            }

            if (_profilePanel.RegistrationToggle.isOn)
            {
                _dataServer.Register(_profilePanel.LoginInputField.text, _profilePanel.PasswordInputField.text, _profilePanel.EmailInputField.text);
            }
            else
            {
                _dataServer.Login(_profilePanel.LoginInputField.text, _profilePanel.PasswordInputField.text);
            }
        }

        private void OnRegistrationToggleValueChangedHandler(bool state)
        {
            _profilePanel.EmailInputField.gameObject.SetActive(state);
            _profilePanel.ActionButtonText.text = state ? REGISTER_BTN_LABLE : LOGIN_BTN_LABLE;
        }

        private void ProfilePanelOnEnableHandler()
        {
            SetInteractions(IsClientLoggedIn);
        }

        private void OnExitClickHandler()
        {
            _profilePanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
        }

        /// <summary>
        /// Check input fields for correct data
        /// </summary>
        /// <returns>True if all is OK. False if something wrong</returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(_profilePanel.LoginInputField.text))
            {
                _infoPanel.ShowError(LOGIN_INCORRECT);
                return false;
            }

            if (string.IsNullOrEmpty(_profilePanel.PasswordInputField.text))
            {
                _infoPanel.ShowError(PASSWORD_INCORRECT);
                return false;
            }

            if (string.IsNullOrEmpty(_profilePanel.EmailInputField.text) && _profilePanel.RegistrationToggle.isOn)
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
            _profilePanel.RegistrationToggle.interactable = !isLoggedin;
            _profilePanel.LoginInputField.interactable = !isLoggedin;
            _profilePanel.PasswordInputField.interactable = !isLoggedin;
            _profilePanel.EmailInputField.interactable = !isLoggedin;

            if (isLoggedin)
            {
                _profilePanel.ActionButtonText.text = LOGOUT_BTN_LABLE;
            }
            else
            {
                OnRegistrationToggleValueChangedHandler(_profilePanel.RegistrationToggle.isOn);
            }
        }

        #endregion

    }
}