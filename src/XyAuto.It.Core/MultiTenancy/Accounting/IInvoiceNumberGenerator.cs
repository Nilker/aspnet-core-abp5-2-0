using System.Threading.Tasks;
using Abp.Dependency;

namespace XyAuto.It.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}
