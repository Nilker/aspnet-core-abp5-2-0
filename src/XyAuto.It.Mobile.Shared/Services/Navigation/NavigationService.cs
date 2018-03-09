using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using XyAuto.It.ApiClient;
using XyAuto.It.Services.Pages;
using XyAuto.It.Views;
using Xamarin.Forms;

namespace XyAuto.It.Services.Navigation
{
    public class NavigationService : INavigationService, ISingletonDependency
    {
        private readonly IAccessTokenManager _accessTokenManager;
        private readonly IPageService _pageService;

        public NavigationService(IAccessTokenManager accessTokenManager, IPageService pageService)
        {
            _accessTokenManager = accessTokenManager;
            _pageService = pageService;
        }

        public async Task InitializeAsync()
        {
            if (_accessTokenManager.IsUserLoggedIn)
            {
                await SetMainPage<MainView>();
            }
            else
            {
                await SetMainPage<LoginView>(clearNavigationHistory: true);
            }
        }

        public async Task SetMainPage<TView>(object navigationParameter = null, bool clearNavigationHistory = false) where TView : IXamarinView
        {
            var page = await _pageService.CreatePage(typeof(TView), navigationParameter);

            if (_pageService.MainPage is NavigationPage navigationPage)
            {
                if (clearNavigationHistory)
                {
                    _pageService.MainPage = new NavigationPage(page); //TODO: Can clear in a different way? And release views..?
                }
                else
                {
                    await navigationPage.Navigation.PushAsync(page);
                }
            }
            else
            {
                _pageService.MainPage = new NavigationPage(page);
            }
        }

        public async Task SetDetailPageAsync(Type viewType, object navigationParameter = null, bool pushToStack = false)
        {
            var currentPage = _pageService.MainPage;

            if (currentPage is NavigationPage)
            {
                currentPage = currentPage.Navigation.NavigationStack.Last();
            }

            if (!(currentPage is MasterDetailPage masterDetailPage))
            {
                throw new Exception($"Current MainPage is not a {typeof(MasterDetailPage)}!");
            }

            var newPage = await _pageService.CreatePage(viewType, navigationParameter);

            if (pushToStack && masterDetailPage.Detail is NavigationPage navPage)
            {
                await navPage.PushAsync(newPage);
            }
            else
            {
                masterDetailPage.Detail = new NavigationPage(newPage);
            }
        }

        public async Task<Page> GoBackAsync()
        {
            if (_pageService.MainPage is NavigationPage navigationPage)
            {
                var currentPage = navigationPage.Navigation.NavigationStack.Last();
                if (currentPage is MasterDetailPage masterDetail && masterDetail.Detail is NavigationPage detailNavigationPage)
                {
                    if (detailNavigationPage.Navigation.NavigationStack.Count > 1)
                    {
                        return await detailNavigationPage.Navigation.PopAsync();
                    }
                }

                return await navigationPage.Navigation.PopAsync();
            }
            else if (_pageService.MainPage is MasterDetailPage masterDetail && masterDetail.Detail is NavigationPage detailNavigationPage)
            {
                return await detailNavigationPage.Navigation.PopAsync();
            }

            return null;
        }
    }
}
