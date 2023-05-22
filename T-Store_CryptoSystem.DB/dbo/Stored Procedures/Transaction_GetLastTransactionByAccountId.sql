CREATE PROCEDURE [dbo].[Transaction_GetLastTransactionByAccountId]
	@AccountId bigint

AS
BEGIN
	SELECT [Id],
		   [AccountId],
		   [Date],
		   [TransactionType],
		   [Amount],
		   [Currency]
	FROM [dbo].[Transaction]
	WHERE [Date] = (SELECT max([Date]) FROM [dbo].[Transaction] WHERE AccountId = @AccountId )
END