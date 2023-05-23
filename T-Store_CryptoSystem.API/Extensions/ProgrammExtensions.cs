﻿using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;
using T_Store_CryptoSystem.BusinessLayer.Services;
using T_Store_CryptoSystem.DataLayer.Repository.interfaces;
using T_Store_CryptoSystem.DataLayer.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using IncredibleBackendContracts.Requests;
using T_Store_CryptoSystem.API.Validations;
using Microsoft.OpenApi.Models;

namespace T_Store_CryptoSystem.API.Extensions;

public static class ProgrammExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ICalculationService, CalculationService>();
        services.AddScoped<IRateService, RateService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }

    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = true);
        services.AddScoped<IValidator<TransactionRequest>, TransactionRequestValidator>();
    }

    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "T-Store",
                Version = "v1"
            });
        });
    }

/*    public static void ConfigureMessaging(this IServiceCollection services)
    {
        services.RegisterConsumersAndProducers((config) =>
        {
            config.AddConsumer<RateConsumer>();
        }, (cfg, ctx) =>
        {
            cfg.ReceiveEndpoint(RabbitEndpoint.CurrencyRates, c =>
            {
                c.ConfigureConsumer<RateConsumer>(ctx);
            });
        }, (cfg) =>
        {
            cfg.RegisterProducer<TransactionCreatedEvent>(RabbitEndpoint.TransactionCreate);
            cfg.RegisterProducer<TransferTransactionCreatedEvent>(RabbitEndpoint.TransferTransactionCreate);
        });
    }*/
}
