using PlayFab.ClientModels;
using PlayFab;
using RTDef.Menu;
using System;
using UnityEngine;

namespace RTDef.PlayFab
{
    public sealed class DataServerConnector
    {

        #region Fields

        private static string LOGIN_SUCCESS = "Login success";
        private static string REGISTRATION_SUCCESS = "Registration success";

        private readonly InfoPanelController _infoPanel;

        private event Action _onLoginSuccess;

        private string _clientUserName;

        #endregion


        #region Properties

        public event Action OnLoginSuccess { add => _onLoginSuccess += value; remove => _onLoginSuccess -= value; }

        public bool IsClientLoggedIn => PlayFabClientAPI.IsClientLoggedIn();
        public string ClientUserName => _clientUserName;

        #endregion


        #region CodeLife

        public DataServerConnector(InfoPanelController infoPanel)
        {
            _infoPanel = infoPanel;
        }

        #endregion


        #region Methods

        public void Logout()
        {
            PlayFabClientAPI.ForgetAllCredentials();
            ResetAccountInfo();
        }

        public void Register(string login, string password, string email)
        {
            PlayFabClientAPI.RegisterPlayFabUser(
                new RegisterPlayFabUserRequest
                {
                    Username = login,
                    Password = password,
                    Email = email,
                    DisplayName = login,
                },

                success =>
                {
                    _infoPanel.ShowSuccess(REGISTRATION_SUCCESS);
                    Login(login, password);
                },

                error =>
                {
                    _infoPanel.ShowError(error.GenerateErrorReport().Remove(0, error.ApiEndpoint.Length + 2));
                }

                );

        }

        public void Login(string login, string password)
        {
            PlayFabClientAPI.LoginWithPlayFab(
                new LoginWithPlayFabRequest
                {
                    Username = login,
                    Password = password,
                },

                success =>
                {
                    _infoPanel.ShowSuccess(LOGIN_SUCCESS);

                    GetAccountInfo();

                    _onLoginSuccess?.Invoke();
                },

                error =>
                {
                    _infoPanel.ShowError(error.GenerateErrorReport().Remove(0, error.ApiEndpoint.Length + 2));
                }
                );
        }

        private void GetAccountInfo()
        {
            PlayFabClientAPI.GetAccountInfo(
                new GetAccountInfoRequest(),

                success =>
                {
                    _clientUserName = success.AccountInfo.TitleInfo.DisplayName;

                    if (string.IsNullOrEmpty(_clientUserName))
                    {
                        _clientUserName = success.AccountInfo.Username;
                    }
                },

                Debug.LogError

                );
        }

        private void ResetAccountInfo()
        {
            _clientUserName = default;
        }

        #endregion

    }
}