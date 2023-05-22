
namespace T_Store_CryptoSystem.DataLayer;

public static class TransactionStoredProcedure
{
    public const string Transaction_Add = "Transaction_Add";
    public const string Transaction_GetAllTransactionsByAccountId = "Transaction_GetAllTransactionsByAccountId";
    public const string Transaction_GetBalanceByAccountId = "Transaction_GetBalanceByAccountId";
    public const string Transaction_GetById = "Transaction_GetById";
    public const string Transaction_GetLastTransactionByAccountId = "Transaction_GetLastTransactionByAccountId";
}
