using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XyAuto.It.MultiTenancy.HostDashboard.Dto;

namespace XyAuto.It.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}
