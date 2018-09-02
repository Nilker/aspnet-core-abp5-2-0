using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XyAuto.It.EntityFrameworkCore
{
    public class SecondDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SecondDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
        public static void Configure(DbContextOptionsBuilder<SecondDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
