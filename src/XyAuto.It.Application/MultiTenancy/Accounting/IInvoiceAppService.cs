using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using XyAuto.It.MultiTenancy.Accounting.Dto;

namespace XyAuto.It.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}

