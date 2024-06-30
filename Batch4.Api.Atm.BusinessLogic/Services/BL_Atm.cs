using Batch4.Api.Atm.DataAccess.Models;
using Batch4.Api.Atm.DataAccess.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Batch4.Api.Atm.BusinessLogic.Services
{
    public class BL_Atm
    {
        private readonly DA_Atm _daAtm;

        public BL_Atm()
        {
            _daAtm = new DA_Atm();
        }

        public string CreateAccount(AccountModel reqModel)
        {
            var result = _daAtm.CreateAccount(reqModel);
            string message = result > 0 ? "Account Created Successfully." : "Account Creation Failed.";
            return message;
        }

        public List<string> GetAllMenu()
        {
            var result= _daAtm.GetAllMenu();
            return result;
        }


        public string Withdraw(string accountNo, decimal amount)
        {
            var result = _daAtm.Withdraw(accountNo, amount);
            string message = result > 0 ? $"{amount} has been dispensed." : "Withdrawal failed. Please check your balance and try again.";
            return message;
        }

    }
}
