using T_Store_CryptoSystem.DataLayer.Enums;

namespace T_Store_CryptoSystem.API.Models.Response;

public class TransferResponse : TransactionResponse
{
    public long RecipientId { get; set; }
    public long RecipientAccountId { get; set; }
    public decimal RecipientAmount { get; set; }
    public Currency RecipientCurrency { get; set; }
}
