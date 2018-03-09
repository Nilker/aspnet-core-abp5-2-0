using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace XyAuto.It.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}

