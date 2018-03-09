using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Abp.Localization;
using Abp.MultiTenancy;
using Acr.UserDialogs;
using MvvmHelpers;
using XyAuto.It.ApiClient;
using XyAuto.It.Authorization.Accounts;
using XyAuto.It.Authorization.Accounts.Dto;
using XyAuto.It.Commands;
using XyAuto.It.Core.DataStorage;
using XyAuto.It.Core.Threading;
using XyAuto.It.Localization;
using XyAuto.It.Localization.Resources;
using XyAuto.It.Services.Account;
using XyAuto.It.ViewModels.Base;
using XyAuto.It.Views;

namespace XyAuto.It.ViewModels
{
    public class LoginViewModel : XamarinViewModel
    {
        public ICommand LoginUserCommand => HttpRequestCommand.Create(LoginUserAsync);
        public ICommand ChangeTenantCommand => HttpRequestCommand.Create(ChangeTenantAsync);
        public ICommand PageAppearingCommand => HttpRequestCommand.Create(PageAppearingAsync);
        public ICommand ForgotPasswordCommand => HttpRequestCommand.Create(ForgotPasswordAsync);
        public ICommand EmailActivationCommand => HttpRequestCommand.Create(EmailActivationAsync);

        public string CurrentTenancyNameOrDefault => _applicationContext.CurrentTenant != null
            ? _applicationContext.CurrentTenant.TenancyName
            : L.Localize("NotSelected");

        private readonly IAccountAppService _accountAppService;
        private readonly IApplicationContext _applicationContext;
        private readonly IDataStorageManager _dataStorageManager;
        private readonly IAccountService _accountService;
        private bool _isLoginEnabled;
        private string _tenancyName;
        private string _navigationData;
        private bool _isAutoLoggingIn;
        private ObservableRangeCollection<LanguageInfo> _languages;
        private LanguageInfo _selectedLanguage;
        private bool _isInitialized;

        public LoginViewModel(
            IAccountAppService accountAppService,
            IApplicationContext applicationContext,
            IDataStorageManager dataStorageManager,
            IAccountService accountService)
        {
            _accountAppService = accountAppService;
            _applicationContext = applicationContext;
            _dataStorageManager = dataStorageManager;
            _accountService = accountService;
            _languages = new ObservableRangeCollection<LanguageInfo>(_applicationContext.Configuration.Localization.Languages);
            _selectedLanguage = _languages.FirstOrDefault(l => l.Name == _applicationContext.CurrentLanguage.Name);
            _isInitialized = false;
        }

        public ObservableRangeCollection<LanguageInfo> Languages
        {
            get => _languages;
            set
            {
                _languages = value;
                RaisePropertyChanged(() => Languages);
            }
        }

        public LanguageInfo SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                RaisePropertyChanged(() => SelectedLanguage);
                if (_isInitialized)
                {
                    AsyncRunner.Run(ChangeLanguage());
                }
            }
        }

        private async Task ForgotPasswordAsync()
        {
            await NavigationService.SetMainPage<ForgotPasswordView>();
        }

        private async Task EmailActivationAsync()
        {
            await NavigationService.SetMainPage<EmailActivationView>();
        }

        private async Task ChangeLanguage()
        {
            _applicationContext.CurrentLanguage = _selectedLanguage;

            await UserConfigurationManager.GetAsync(async () =>
            {
                await NavigationService.SetMainPage<LoginView>(clearNavigationHistory: true);
            });
        }

        private bool IsFromLogout()
        {
            return _navigationData == "From-Logout";
        }

        private void PopulateCredentialsFromStorage()
        {
            UserName = _dataStorageManager.Retrieve(DataStorageKey.Username, "");
            TenancyName = _dataStorageManager.Retrieve(DataStorageKey.TenancyName, "");
            var tenantId = _dataStorageManager.Retrieve<int?>(DataStorageKey.TenantId, null);

            if (tenantId == null)
            {
                _applicationContext.SetAsHost();
            }
            else
            {
                _applicationContext.SetAsTenant(TenancyName, tenantId.Value);
            }

            SetPassword();
            RaisePropertyChanged(() => CurrentTenancyNameOrDefault);
        }

        private async Task PageAppearingAsync()
        {
            PopulateCredentialsFromStorage();
            await AutoLoginIfRequired();
        }

        public override Task InitializeAsync(object navigationData)
        {
            _navigationData = (string)navigationData;
            _isInitialized = true;
            return Task.CompletedTask;
        }

        public string TenancyName
        {
            get => _tenancyName;
            set
            {
                _tenancyName = value;
                RaisePropertyChanged(() => TenancyName);
            }
        }

        public string UserName
        {
            get => _accountService.AbpAuthenticateModel.UserNameOrEmailAddress;
            set
            {
                _accountService.AbpAuthenticateModel.UserNameOrEmailAddress = value;
                SetLoginButtonEnabled();
                RaisePropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get => _accountService.AbpAuthenticateModel.Password;
            set
            {
                _accountService.AbpAuthenticateModel.Password = value;
                SetLoginButtonEnabled();
                RaisePropertyChanged(() => Password);
            }
        }

        public void SetLoginButtonEnabled()
        {
            IsLoginEnabled = !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }

        public bool IsLoginEnabled
        {
            get => _isLoginEnabled;
            set
            {
                _isLoginEnabled = value;
                RaisePropertyChanged(() => IsLoginEnabled);
            }
        }

        public bool IsAutoLoggingIn
        {
            get => _isAutoLoggingIn;
            set
            {
                _isAutoLoggingIn = value;
                RaisePropertyChanged(() => IsAutoLoggingIn);
            }
        }

        private void SetPassword()
        {
            if (IsFromLogout())
            {
                Password = null;
                _dataStorageManager.RemoveIfExists(DataStorageKey.Password);
            }
            else
            {
                Password = _dataStorageManager.Retrieve(DataStorageKey.Password, "", true);
            }
        }

        private async Task AutoLoginIfRequired()
        {
            if (Password == null)
            {
                return;
            }

            IsAutoLoggingIn = true;
            await SetBusyAsync(async () =>
            {
                await LoginUserAsync();
                IsAutoLoggingIn = false;
            }, LocalTranslation.Authenticating);
        }

        private async Task LoginUserAsync()
        {
            await SetBusyAsync(async () =>
            {
                await _accountService.LoginUserAsync();
            });
        }

        private async Task ChangeTenantAsync()
        {
            var promptResult = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                Message = L.Localize("LeaveEmptyToSwitchToHost"),
                Text = _applicationContext.CurrentTenant?.TenancyName ?? "",
                OkText = L.Localize("Ok"),
                CancelText = L.Localize("Cancel"),
                Title = L.Localize("ChangeTenant"),
                Placeholder = L.LocalizeWithThreeDots("TenancyName"),
                MaxLength = AbpTenantBase.MaxTenancyNameLength
            });

            if (!promptResult.Ok)
            {
                return;
            }

            if (string.IsNullOrEmpty(promptResult.Text))
            {
                _applicationContext.SetAsHost();
                ApiUrlConfig.ResetBaseUrl();
                RaisePropertyChanged(() => CurrentTenancyNameOrDefault);
            }
            else
            {
                await SetTenantAsync(promptResult.Text);
            }
        }

        private async Task SetTenantAsync(string tenancyName)
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(
                    async () => await _accountAppService.IsTenantAvailable(
                        new IsTenantAvailableInput { TenancyName = tenancyName }),
                    result => IsTenantAvailableExecuted(result, tenancyName)
                );
            });
        }

        private async Task IsTenantAvailableExecuted(IsTenantAvailableOutput result, string tenancyName)
        {
            var tenantAvailableResult = result;

            switch (tenantAvailableResult.State)
            {
                case TenantAvailabilityState.Available:
                    _applicationContext.SetAsTenant(tenancyName, tenantAvailableResult.TenantId.Value);
                    ApiUrlConfig.ChangeBaseUrl(tenantAvailableResult.ServerRootAddress);
                    RaisePropertyChanged(() => CurrentTenancyNameOrDefault);
                    break;
                case TenantAvailabilityState.InActive:
                    UserDialogs.Instance.HideLoading();
                    await UserDialogs.Instance.AlertAsync(L.Localize("TenantIsNotActive", tenancyName));
                    break;
                case TenantAvailabilityState.NotFound:
                    UserDialogs.Instance.HideLoading();
                    await UserDialogs.Instance.AlertAsync(L.Localize("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

