
namespace T_Store_CryptoSystem.BusinessLayer.Models;

public class RatesEvent
{
    public Dictionary<string, decimal> Rates { get; set; }

    public RatesEvent()
    {
        Rates = new Dictionary<string, decimal>();
    }
}
