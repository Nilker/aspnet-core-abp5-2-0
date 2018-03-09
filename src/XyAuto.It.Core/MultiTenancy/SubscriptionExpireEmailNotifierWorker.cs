using System;
using System.Diagnostics;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using XyAuto.It.Authorization.Users;

namespace XyAuto.It.MultiTenancy
{
    public class SubscriptionExpireEmailNotifierWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private const int CheckPeriodAsMilliseconds = 1 * 60 * 60 * 1000 * 24; //1 day
        private const int SubscriptionRemainingDayCount = 3;

        private readonly IRepository<Tenant> _tenantRepository;
        private readonly UserEmailer _userEmailer;

        public SubscriptionExpireEmailNotifierWorker(
            AbpTimer timer,
            IRepository<Tenant> tenantRepository,
            UserEmailer userEmailer) : base(timer)
        {
            _tenantRepository = tenantRepository;
            _userEmailer = userEmailer;

            Timer.Period = CheckPeriodAsMilliseconds;
            Timer.RunOnStart = true;

            LocalizationSourceName = AbpZeroTemplateConsts.LocalizationSourceName;
        }

        protected override void DoWork()
        {
            var dateToCheckRemainingDayCount = Clock.Now.AddDays(SubscriptionRemainingDayCount).ToUniversalTime();

            var subscriptionExpiredTenants = _tenantRepository.GetAllList(
                tenant => tenant.SubscriptionEndDateUtc != null &&
                          tenant.SubscriptionEndDateUtc.Value.Date == dateToCheckRemainingDayCount.Date &&
                          tenant.IsActive &&
                          tenant.EditionId != null
            );

            foreach (var tenant in subscriptionExpiredTenants)
            {
                Debug.Assert(tenant.EditionId.HasValue);
                try
                {
                    _userEmailer.TryToSendSubscriptionExpiringSoonEmail(tenant.Id, dateToCheckRemainingDayCount);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception.Message, exception);
                }
            }
        }
    }
}

