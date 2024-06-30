using Batch4.Api.Atm.DataAccess.Models;
using Batch4.Api.Atm.DataAccess.Services;

namespace Batch4.Api.Atm.BusinessLogic.Services;

public class BL_Atm
{
    private readonly DA_Atm _daAtm;

    public BL_Atm(DA_Atm daAtm)
    {
        _daAtm = daAtm;
    }

    public List<string> GetAllMenu()
    {
        var result = _daAtm.GetAllMenu();
        return result;
    }

    public async Task<string> CreateAccount(AccountModel reqModel)
    {
        var result = await _daAtm.CreateAccount(reqModel);
        string message = result > 0 ? "Account Created Successfully." : "Account Creation Failed.";
        return message;
    }

    public async Task<string> CreateUser(UserModel requestModel)
    {
        var result = await _daAtm.CreateUser(requestModel);
        string message = result > 0 ? "User Created Successfully." : "User Creation Failed.";
        return message;
    }

    public async Task<string> UserLogin(int id, string password)
    {
        var user = await _daAtm.GetUser(id);
        if (user is null)
        {
            return "Invalid User.";
        }

        if (user.Password != password)
        {
            return "Invalid Password.";
        }

        return "Login Successful.";
    }

    public async Task<string> AccountLogin(string accountNo, string pin)
    {
        var account = await _daAtm.GetAccount(accountNo);
        if (account is null)
        {
            return "Invalid Account.";
        }

        if (account.Pin != pin)
        {
            return "Invalid Pin.";
        }

        return "Login Successful.";
    }

    public async Task<decimal> CheckBalance(string accountNo)
    {
        var result = await _daAtm.CheckBalance(accountNo);
        return result;
    }

    public async Task<string> Withdraw(string accountNo, decimal amount)
    {
        var result = await _daAtm.Withdraw(accountNo, amount);
        string message = result > 0
            ? $"{amount} has been dispensed."
            : "Withdrawal failed. Please check your balance and try again.";
        return message;
    }

    public async Task<string> Deposit(string accountNo, decimal amount)
    {
        var result = await _daAtm.Deposit(accountNo, amount);
        string message = result > 0
            ? $"{amount} has been deposited."
            : "Deposit failed. Please check your account and try again.";
        return message;
    }
}