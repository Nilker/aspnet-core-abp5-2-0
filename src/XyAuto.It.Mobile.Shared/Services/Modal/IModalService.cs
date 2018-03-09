using System.Threading.Tasks;
using XyAuto.It.Views;
using Xamarin.Forms;

namespace XyAuto.It.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}

