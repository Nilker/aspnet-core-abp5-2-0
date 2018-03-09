using System.Data.Common;
using System.Data.SqlClient;
using Abp.Extensions;

namespace XyAuto.It.EntityFrameworkCore
{
    public static class DatabaseCheckHelper
    {
        public static bool Exist(string connectionString)
        {
            if (connectionString.IsNullOrEmpty())
            {
                //connectionString is null for unit tests
                return true;
            }

            using (DbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }
    }
}

