using Batch4.Api.Atm.BusinessLogic.Services;
using Batch4.Api.Atm.DataAccess.Db;
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

        [HttpGet]
        public IActionResult GetAccounts()
        {
            var lst = _blAtm.GetAccounts();
            return Ok(lst);
        }
    }
}
