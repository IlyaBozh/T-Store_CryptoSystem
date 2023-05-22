CREATE PROCEDURE [dbo].[Transaction_GetAllTransactionsByAccountId]
@AccountId bigint
AS
BEGIN

	WITH T AS
	(
		SELECT [Date]
		FROM   [dbo].[Transaction]
		WHERE  (AccountId =@AccountId )
	)

	SELECT [Id],
		   [AccountId],
		   [Date],
		   [TransactionType],
		   [Amount],
		   [Currency]
	FROM   [dbo].[Transaction]
	WHERE  [Date] in (SELECT [Date] FROM T)
END		
