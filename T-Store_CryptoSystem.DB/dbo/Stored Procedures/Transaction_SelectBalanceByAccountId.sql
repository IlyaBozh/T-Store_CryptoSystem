CREATE PROCEDURE [dbo].[Transaction_SelectBalanceByAccountId]
	@AccountId bigint

AS
BEGIN

	SELECT coalesce(sum([Amount]),0)
	FROM [dbo].[Transaction]
	WHERE [AccountId] = @AccountId
END
