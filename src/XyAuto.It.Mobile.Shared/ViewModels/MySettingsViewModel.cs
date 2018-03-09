using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Abp.Localization;
using MvvmHelpers;
using XyAuto.It.ApiClient;
using XyAuto.It.ApiClient.Models;
using XyAuto.It.Authorization.Users.Dto;
using XyAuto.It.Authorization.Users.Profile;
using XyAuto.It.Core.Threading;
using XyAuto.It.ViewModels.Base;
using XyAuto.It.Views;
using Xamarin.Forms;

namespace XyAuto.It.ViewModels
{
    public class MySettingsViewModel : XamarinViewModel
    {
        public ICommand LogoutCommand => AsyncCommand.Create(Logout);
        public ICommand ChangePasswordCommand => AsyncCommand.Create(ChangePasswordAsync);

        private readonly IAccessTokenManager _accessTokenManager;
        private readonly IApplicationContext _applicationContext;
        private readonly AbpAuthenticateModel _abpAuthenticateModel;
        private readonly IProfileAppService _profileAppService;
        private ObservableRangeCollection<LanguageInfo> _languages;
        private LanguageInfo _selectedLanguage;
        private bool _isInitialized;

        public MySettingsViewModel(
            IAccessTokenManager accessTokenManager,
            IApplicationContext applicationContext,
            AbpAuthenticateModel abpAuthenticateModel,
            IProfileAppService profileAppService)
        {
            _accessTokenManager = accessTokenManager;
            _applicationContext = applicationContext;
            _abpAuthenticateModel = abpAuthenticateModel;
            _profileAppService = profileAppService;
            _languages = new ObservableRangeCollection<LanguageInfo>(_applicationContext.Configuration.Localization.Languages);
            _selectedLanguage = _languages.FirstOrDefault(l => l.Name == _applicationContext.CurrentLanguage.Name);
            _isInitialized = false;
        }

        public override Task InitializeAsync(object navigationData)
        {
            _isInitialized = true;

            return Task.CompletedTask;
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

        private async Task ChangeLanguage()
        {
            _applicationContext.CurrentLanguage = _selectedLanguage;

            await WebRequestExecuter.Execute(
                async () =>
                    await _profileAppService.ChangeLanguage(new ChangeUserLanguageDto
                    {
                        LanguageName = _selectedLanguage.Name
                    }),
                async () =>
                    await UserConfigurationManager.GetAsync(async () =>
                    {
                        MessagingCenter.Send(this, MessagingCenterKeys.LanguagesChanged);
                        await NavigationService.SetDetailPageAsync(typeof(MySettingsView));
                    }));
        }

        private async Task ChangePasswordAsync()
        {
            await NavigationService.SetMainPage<ChangePasswordView>();
        }

        private async Task Logout()
        {
            _accessTokenManager.Logout();
            _applicationContext.LoginInfo = null;
            _abpAuthenticateModel.Password = null;
            await NavigationService.SetMainPage<LoginView>("From-Logout", clearNavigationHistory: true);
        }
    }
}

