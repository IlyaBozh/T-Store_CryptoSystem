CREATE PROCEDURE [dbo].[Transaction_GetBalanceByAccountId]
	@AccountId bigint

AS
BEGIN

	SELECT coalesce(sum([Amount]),0)
	FROM [dbo].[Transaction]
	WHERE [AccountId] = @AccountId
END
