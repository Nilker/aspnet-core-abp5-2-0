using System;
using System.Threading.Tasks;
using Abp.Dependency;
using XyAuto.It.Core.Dependency;
using XyAuto.It.ViewModels.Base;
using Xamarin.Forms;

namespace XyAuto.It.Services.Pages
{
    public class PageService : IPageService, ISingletonDependency
    {
        public Page MainPage
        {
            get => Application.Current.MainPage;
            set => Application.Current.MainPage = value;
        }

        public async Task<Page> CreatePage(Type viewType, object navigationParameter)
        {
            var view = (Page)DependencyResolver.Resolve(viewType);
            if (!(view.BindingContext is XamarinViewModel viewModel))
            {
                throw new Exception($"BindingContext of views must inherit {nameof(XamarinViewModel)}. Given view's BindingContext is not like that: {viewType}");
            }

            await viewModel.InitializeAsync(navigationParameter);
            return view;
        }
    }
}
