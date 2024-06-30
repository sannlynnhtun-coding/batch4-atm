using Batch4.Api.Atm.BusinessLogic.Services;
using Batch4.Api.Atm.DataAccess.Db;
using Batch4.Api.Atm.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.Atm.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        public readonly BL_Atm _blAtm;

        public AtmController(BL_Atm blAtm)
        {
            _blAtm = blAtm;
        }

        [HttpPost("create account")]
        public IActionResult CreateAccount(AccountModel reqModel)
        {
            var result = _blAtm.CreateAccount(reqModel);
            return Ok(result);
        }

        [HttpGet("GetAllMenu")]
        public IActionResult GetAllMenu()
        {
            var lst = _blAtm.GetAllMenu();
            return Ok(lst);
        }

        [HttpPost("withdraw {accountNo}/{amount}")]
        public IActionResult Withdraw(string accountNo, decimal amount)
        {
            var result = _blAtm.Withdraw(accountNo, amount);
            return Ok(result);
        }
    }
}
