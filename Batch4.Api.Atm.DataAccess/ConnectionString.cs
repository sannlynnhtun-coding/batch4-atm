using System.Data.SqlClient;

namespace Batch4.Api.Atm.DataAccess
{
    public static class ConnectionString
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "ZAKAWARMAW\\SQL2022",
            InitialCatalog = "ATM",
            UserID = "sa",
            Password = "sa@123",
           TrustServerCertificate = true,
        };
    }
}
