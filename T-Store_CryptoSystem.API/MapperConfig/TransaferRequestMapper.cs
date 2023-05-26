using AutoMapper;
using T_Store_CryptoSystem.API.Models.Request;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.DataLayer.Enums;

namespace T_Store_CryptoSystem.API.MapperConfig;

public class TransaferRequestMapper : ITypeConverter<TransactionTransferRequest, List<TransactionModel>>
{
    public List<TransactionModel> Convert(TransactionTransferRequest source, List<TransactionModel> destination, ResolutionContext context)
    {

        destination = new List<TransactionModel>()
         {
            new TransactionModel()
            {
                AccountId = source.AccountId,
                Amount = source.Amount,
                Currency = source.Currency,
                TransactionType = TransactionType.Withdraw

            },
            new TransactionModel()
            {
                AccountId = source.RecipientAccountId,
                Currency = source.RecipientCurrency,
                TransactionType = TransactionType.Withdraw

            },
         };

        return context.Mapper.Map<List<TransactionModel>>(destination);
    }
}
