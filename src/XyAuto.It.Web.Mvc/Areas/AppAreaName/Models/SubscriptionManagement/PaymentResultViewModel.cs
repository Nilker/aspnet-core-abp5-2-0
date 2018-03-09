using Abp.AutoMapper;
using XyAuto.It.Editions;
using XyAuto.It.MultiTenancy.Payments.Dto;

namespace XyAuto.It.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}

