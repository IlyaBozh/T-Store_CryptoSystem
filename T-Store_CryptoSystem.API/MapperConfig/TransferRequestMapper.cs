using AutoMapper;
using T_Store_CryptoSystem.BusinessLayer.Models;
using CryptoSystem_NuGetPackage.Enums;
using CryptoSystem_NuGetPackage.Requests;

namespace T_Store_CryptoSystem.API.MapperConfig;

public class TransferRequestMapper : ITypeConverter<TransactionTransferRequest, List<TransactionModel>>
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
