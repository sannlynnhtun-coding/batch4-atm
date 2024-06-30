using Batch4.Api.Atm.DataAccess.Models;
using Batch4.Api.Atm.DataAccess.Services;

namespace Batch4.Api.Atm.BusinessLogic.Services
{
    public class BL_Atm
    {
        private readonly DA_Atm _daAtm;

        public BL_Atm()
        {
            _daAtm = new DA_Atm();
        }

        public List<AccountModel> GetAccounts()
        {
            var lst = _daAtm.GetAccounts();
            return lst;
        }

        public string CreateAccount(AccountModel reqModel)
        {
            var result = _daAtm.CreateAccount(reqModel);
            string message = result > 0 ? "Account Created Successfully." : "Account Creation Failed.";
            return message;
        }
    }
}
