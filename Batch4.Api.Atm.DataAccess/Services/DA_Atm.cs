using Batch4.Api.Atm.DataAccess.Db;
using Batch4.Api.Atm.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.Atm.DataAccess.Services;

public class DA_Atm
{
    private readonly AppDbContext _context;

    public DA_Atm(AppDbContext context)
    {
        _context = context;
    }

    public List<string> GetAllMenu()
    {
        var lst = new List<string>
        {
            "1. Check Balance",
            "2. Withdraw Cash",
            "3. Deposit Cash",
            "4. Exit"
        };
        return lst;
    }

    public async Task<int> CreateAccount(AccountModel reqModel)
    {
        await _context.Accounts.AddAsync(reqModel);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<AccountModel?> GetAccount(string accountNo)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNo == accountNo);
        return account;
    }

    public async Task<decimal> CheckBalance(string accountNo)
    {
        var account = await GetAccount(accountNo);
        if (account is null) return 0;
        return account.Balance;
    }

    public async Task<int> Withdraw(string accountNo, decimal amount)
    {
        var account = await GetAccount(accountNo);
        if (account is null) return 0;

        if (amount > account.Balance) return 0;

        account.Balance -= amount;
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<int> Deposit(string accountNo, decimal amount)
    {
        var account = await GetAccount(accountNo);
        if (account is null) return 0;

        account.Balance += amount;
        var result = await _context.SaveChangesAsync();
        return result;
    }


    public async Task<UserModel?> GetUser(int id)
    {
        var item = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        return item;
    }

    public async Task<int> CreateUser(UserModel requestModel)
    {
        await _context.Users.AddAsync(requestModel);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<int> UpdateUser(int id, UserModel requestModel)
    {
        var item = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        if (item is null) return 0;

        item.UserName = requestModel.UserName;
        item.Password = requestModel.Password;
        item.Email = requestModel.Email;

        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<int> DeleteUser(int id)
    {
        var item = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        if (item is null) return 0;

        _context.Users.Remove(item);
        var result = await _context.SaveChangesAsync();
        return result;
    }
}