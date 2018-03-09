using System.Threading.Tasks;
using Abp.Application.Services;
using XyAuto.It.MultiTenancy.Dto;
using XyAuto.It.MultiTenancy.Payments.Dto;
using Abp.Application.Services.Dto;

namespace XyAuto.It.MultiTenancy.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<PaymentInfoDto> GetPaymentInfo(PaymentInfoInput input);

        Task<CreatePaymentResponse> CreatePayment(CreatePaymentDto input);

        Task<ExecutePaymentResponse> ExecutePayment(ExecutePaymentDto input);

        Task<PagedResultDto<SubscriptionPaymentListDto>> GetPaymentHistory(GetPaymentHistoryInput input);
    }
}

