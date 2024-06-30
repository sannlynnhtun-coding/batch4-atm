using Batch4.Api.Atm.DataAccess.Db;
using Batch4.Api.Atm.DataAccess.Models;

namespace Batch4.Api.Atm.DataAccess.Services
{
    //DataAccess

    public class DA_Atm
    {
        private readonly AppDbContext _context;

        public DA_Atm()
        {
            _context = new AppDbContext();
        }

        public List<AccountModel> GetAccounts()
        {
            var lst = _context.Accounts.ToList();
            return lst;
        }

        public int CreateAccount(AccountModel reqModel)
        {
            _context.Accounts.Add(reqModel);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
