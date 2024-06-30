using Batch4.Api.Atm.BusinessLogic.Services;
using Batch4.Api.Atm.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.Atm.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AtmController : ControllerBase
{
    public readonly BL_Atm _bl_Atm;

    public AtmController(BL_Atm blAtm)
    {
        _bl_Atm = blAtm;
    }

    [HttpGet("get-all-menu")]
    public IActionResult GetAllMenu()
    {
        var lst = _bl_Atm.GetAllMenu();
        return Ok(lst);
    }


    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser(UserModel reqModel)
    {
        var result = await _bl_Atm.CreateUser(reqModel);
        return Ok(result);
    }

    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount(AccountModel reqModel)
    {
        var result = await _bl_Atm.CreateAccount(reqModel);
        return Ok(result);
    }

    [HttpPost("user-login/{id}/{password}")]
    public async Task<IActionResult> UserLogin(int id, string password)
    {
        var result = await _bl_Atm.UserLogin(id, password);
        return Ok(result);
    }

    [HttpPost("account-login/{accountNo}/{password}")]
    public async Task<IActionResult> AccountLogin(string accountNo, string password)
    {
        var result = await _bl_Atm.AccountLogin(accountNo, password);
        return Ok(result);
    }

    [HttpGet("check-balance/{accountNo}")]
    public async Task<IActionResult> CheckBalance(string accountNo)
    {
        var result = await _bl_Atm.CheckBalance(accountNo);
        return Ok(result);
    }

    [HttpPost("withdraw/{accountNo}/{amount}")]
    public async Task<IActionResult> Withdraw(string accountNo, decimal amount)
    {
        var result = await _bl_Atm.Withdraw(accountNo, amount);
        return Ok(result);
    }

    [HttpPost("deposit/{accountNo}/{amount}")]
    public async Task<IActionResult> Deposit(string accountNo, decimal amount)
    {
        var result = await _bl_Atm.Deposit(accountNo, amount);
        return Ok(result);
    }
}