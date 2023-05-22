
namespace T_Store_CryptoSystem.BusinessLayer.Exceptions;

public class BalanceExceedException : Exception
{
    public BalanceExceedException(string message) : base(message) { }
}
