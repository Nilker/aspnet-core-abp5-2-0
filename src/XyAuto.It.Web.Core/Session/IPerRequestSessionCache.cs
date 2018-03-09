using System.Threading.Tasks;
using XyAuto.It.Sessions.Dto;

namespace XyAuto.It.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}


