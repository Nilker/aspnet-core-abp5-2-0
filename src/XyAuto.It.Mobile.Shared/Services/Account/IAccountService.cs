using System.Threading.Tasks;
using XyAuto.It.ApiClient.Models;

namespace XyAuto.It.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        Task LoginUserAsync();
    }
}

