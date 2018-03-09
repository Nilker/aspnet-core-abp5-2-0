using System.Threading.Tasks;

namespace XyAuto.It.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}
