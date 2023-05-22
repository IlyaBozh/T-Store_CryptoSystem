using AutoMapper;
using IncredibleBackendContracts.Requests;
using IncredibleBackendContracts.Responses;
using T_Store_CryptoSystem.BusinessLayer.Models;

namespace T_Store_CryptoSystem.API.MapperConfig;

public class MapperConfigAPI : Profile
{
    public MapperConfigAPI()
    {

        CreateMap<TransactionRequest, TransactionModel>();

        CreateMap<TransactionModel, TransactionResponse>();

        CreateMap<Dictionary<DateTime, List<TransactionModel>>, List<TransactionResponse>>()
           .ConvertUsing<TransactionResponseMapper>();
    }

}
