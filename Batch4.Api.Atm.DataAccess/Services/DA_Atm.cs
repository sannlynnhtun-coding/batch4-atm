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

        public int CreateAccount(AccountModel reqModel)
        {
            _context.Accounts.Add(reqModel);
            var result = _context.SaveChanges();
            return result;
        }

        public int Withdraw(string accountNo, decimal amount)
        {
            var atm = _context.Accounts.FirstOrDefault(x => x.AccountNo == accountNo);
            if (atm is null) return 0;

            if (amount > atm.Balance) return 0;

            atm.Balance -= amount;
            var result = _context.SaveChanges();
            return result;
        }

        public List<string> GetAllMenu()
        {
            var lst = new List<string>();
            lst.Add("1. Check Balance");
            lst.Add("2. Withdraw Cash");
            lst.Add("3. Deposit Cash");
            lst.Add("4. Exit");
            return lst;
        }
    }
}
