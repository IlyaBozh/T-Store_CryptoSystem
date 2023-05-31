using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Data.SqlClient;
using System.Data;
using T_Store_CryptoSystem.API.Infrastructure;
using NLog.Web;
using T_Store_CryptoSystem.API.Extensions;
using T_Store_CryptoSystem.API.MapperConfig;
using T_Store_CryptoSystem.BusinessLayer.MapperConfig;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

var dbConfig = new DbConfig();
builder.Configuration.Bind(dbConfig);

LogManager.Configuration.Variables[$"{environment: LOG_DIRECTORY}"] = "Logs";

builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(dbConfig.TSTORE_DB_CONNECTION_STRING));

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new BadRequestObjectResult(context.ModelState);
            result.StatusCode = StatusCodes.Status422UnprocessableEntity;
            return result;
        };

    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMessaging();
builder.Services.AddFluentValidation();
builder.Services.AddServices();
builder.Services.AddRepositories();
/*builder.Services.AddProducers();*/
builder.Services.AddAutoMapper(typeof(MapperConfigBusiness), typeof(MapperConfigAPI));
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();
/*app.UseCustomExceptionHandler();*/
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
app.UseAdminSafeList();
app.Run();
