
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using XyAuto.It.Configuration;
using XyAuto.It.EntityFrameworkCore;

namespace XyAuto.It
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SecondDbContext>
    {
       
        public SecondDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SecondDbContext>();
            builder.UseSqlServer("Server=localhost; Database=5_2_0_AbpZeroTemplateDb_2; Trusted_Connection=True;");
            return new SecondDbContext(builder.Options);
        }
    }
}
