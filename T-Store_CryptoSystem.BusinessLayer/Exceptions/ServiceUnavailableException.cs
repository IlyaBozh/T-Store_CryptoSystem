
namespace T_Store_CryptoSystem.BusinessLayer.Exceptions;

public class ServiceUnavailableException : Exception
{
    public ServiceUnavailableException(string message) : base(message) { }
}
