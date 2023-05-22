
using AutoMapper;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.DataLayer.Models;

namespace T_Store_CryptoSystem.BusinessLayer.MapperConfig;

public class MapperConfigBusiness : Profile
{
    public MapperConfigBusiness()
    {
        CreateMap<TransactionModel, TransactionDto>().ReverseMap();
        /*CreateMap<TransactionModel, TransactionCreatedEvent>();*/
    }
}
