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
    }
}
