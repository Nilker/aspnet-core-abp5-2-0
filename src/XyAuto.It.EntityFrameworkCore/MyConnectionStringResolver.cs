using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XyAuto.It.Configuration;
using XyAuto.It.EntityFrameworkCore;
using XyAuto.It.Web;

namespace XyAuto.It
{
    public class MyConnectionStringResolver : DefaultConnectionStringResolver
    {
        public MyConnectionStringResolver(IAbpStartupConfiguration configuration)
            : base(configuration)
        {
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args["DbContextConcreteType"] as Type == typeof(SecondDbContext))
            {
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                return configuration.GetConnectionString(MultipleDbContextEfCoreDemoConsts.SecondDbConnectionStringName);
            }

            return base.GetNameOrConnectionString(args);
        }
    }
}
