using System.Threading.Tasks;
using Abp.Application.Services;

namespace XyAuto.It.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}

