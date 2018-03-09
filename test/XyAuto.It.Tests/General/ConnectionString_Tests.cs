using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace XyAuto.It.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=AbpZeroTemplate; Trusted_Connection=True;");
            csb["Database"].ShouldBe("AbpZeroTemplate");
        }
    }
}

