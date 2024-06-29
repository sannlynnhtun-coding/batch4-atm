using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.Atm.DataAccess.Models;

[Table("Tbl_Account")]
public class AccountModel
{
    [Key]
    public string AccountNo { get; set; }
    public string? Pin { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}
