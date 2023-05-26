using T_Store_CryptoSystem.DataLayer.Enums;

namespace T_Store_CryptoSystem.API.Models.Request;

public class TransactionRequest
{
    public long AccountId { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
}
