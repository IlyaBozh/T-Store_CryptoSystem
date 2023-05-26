using T_Store_CryptoSystem.DataLayer.Enums;

namespace T_Store_CryptoSystem.API.Models.Request;

public class TransactionTransferRequest : TransactionRequest
{
    public long RecipientAccountId { get; set; }
    public Currency RecipientCurrency { get; set; }
}
