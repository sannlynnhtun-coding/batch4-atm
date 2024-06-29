using Microsoft.EntityFrameworkCore;
using Batch4.Api.Atm.DataAccess.Models;

namespace Batch4.Api.Atm.DataAccess.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
    }
}
