
using CryptoSystem_NuGetPackage.Events;

namespace T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface IRatesHistoryService
{
    Task<NewRatesHistoryEvent> SendInfo(RatesInfoEvent info);
    Task SaveRatesHistory(Dictionary<string, List<decimal>> history);
}