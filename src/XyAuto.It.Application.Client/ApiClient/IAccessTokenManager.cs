using System.Threading.Tasks;
using XyAuto.It.ApiClient.Models;

namespace XyAuto.It.ApiClient
{
    public interface IAccessTokenManager
    {
        Task<string> GetAccessTokenAsync();
         
        Task<AbpAuthenticateResultModel> LoginAsync();

        void Logout();

        bool IsUserLoggedIn { get; }
    }
}
