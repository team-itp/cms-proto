using CmsClient.Models;
using CmsClient.Properties;
using CmsClient.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CmsClient.ViewModels
{
    public delegate void LoginCompletedCallback(LoginCredential credential);

    public class LoginViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _userId;
        private string _password;
        private string _error;
        private bool _isBusy;
        private LoginService _loginService;
        private LoginCompletedCallback _loginCompletedCallback;
        private InitialSettingBackHandler _backHandler;

        public string UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
                HasErrorUpdated();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                HasErrorUpdated();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public override bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(Verify(nameof(UserId))) || !string.IsNullOrEmpty(Verify(nameof(Password)));
            }
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return _error;
            }
        }

        public LoginViewModel(LoginService loginService, LoginCompletedCallback loginCompletedCallback, InitialSettingBackHandler backHandler)
        {
            _loginService = loginService;
            _loginCompletedCallback = loginCompletedCallback;
            _backHandler = backHandler;
        }

        protected override string Verify(string columnName)
        {
            switch (columnName)
            {
                case nameof(UserId):
                    return VerifyUserId();
                case nameof(Password):
                    return VerifyPassword();
                default:
                    return null;
            }
        }

        private string VerifyUserId()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                return Resources.USER_ID_IS_EMPTY;
            }
            return string.Empty;
        }

        private string VerifyPassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                return Resources.PASSWORD_IS_EMPTY;
            }
            return string.Empty;
        }

        public bool CanLogin()
        {
            return !HasError;
        }

        public async Task Login()
        {
            if (HasError)
                throw new InvalidOperationException();

            try
            {
                var credential = await _loginService.Login(UserId, Password);
                _loginCompletedCallback.Invoke(credential);
            }
            catch (LoginFailedException ex)
            {
                _error = ex.Message;
            }
        }

        public void Back()
        {
            _backHandler.Invoke();
        }
    }
}
