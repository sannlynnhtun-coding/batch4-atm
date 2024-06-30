using Batch4.Api.Atm.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.Atm.DataAccess.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<AccountModel> Accounts { get; set; }
}