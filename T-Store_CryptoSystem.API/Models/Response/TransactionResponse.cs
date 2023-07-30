using CryptoSystem_NuGetPackage.Enums;

namespace T_Store_CryptoSystem.API.Models.Response;

public class TransactionResponse
{
    public long Id { get; set; }
    public long AccountId { get; set; }
    public DateTime Date { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
}
