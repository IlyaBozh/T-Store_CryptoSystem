﻿using AutoMapper;
using CryptoSystem_NuGetPackage.Requests;
using T_Store_CryptoSystem.API.Models.Response;
using T_Store_CryptoSystem.BusinessLayer.Models;

namespace T_Store_CryptoSystem.API.MapperConfig;

public class MapperConfigAPI : Profile
{
    public MapperConfigAPI()
    {

        CreateMap<TransactionRequest, TransactionModel>();

        CreateMap<TransactionModel, TransactionResponse>();

        CreateMap<TransactionTransferRequest, List<TransactionModel>>()
            .ConvertUsing<TransferRequestMapper>();

        CreateMap<Dictionary<DateTime, List<TransactionModel>>, List<TransactionResponse>>()
           .ConvertUsing<TransactionResponseMapper>();
    }

}
