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

        [HttpGet("accounts")]
        public IActionResult GetAccounts()
        {
            var lst = _blAtm.GetAccounts();
            return Ok(lst);
        }

        [HttpPost("create account")]
        public IActionResult CreateAccount(AccountModel reqModel)
        {
            var result = _blAtm.CreateAccount(reqModel);
            return Ok(result);
        }
        
    }
}
