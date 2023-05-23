CREATE PROCEDURE [dbo].[Transaction_Add]
	@AccountId bigint,
	@Date datetime2(7),
	@TransactionType tinyint,
	@Amount decimal (11,4),
	@Currency smallint
AS
BEGIN
BEGIN TRANSACTION

		INSERT INTO [dbo].[Transaction] WITH (TABLOCK, HOLDLOCK) 
		(
			[AccountId],
			[Date],
			[TransactionType],
			[Amount],
			[Currency]
		)
		VALUES 
		(
			@AccountId, 
			sysdatetime(), 
			@TransactionType, 
			@Amount, 
			@Currency
		)

		DECLARE @actualBalance decimal (11,4)
		SET @actualBalance = (SELECT coalesce(sum([Amount]),0)
							  FROM [dbo].[Transaction] WITH (TABLOCK, HOLDLOCK) 
							  WHERE [AccountId] = @AccountId)

		IF @actualBalance<0
		ROLLBACK

		ELSE		
		SELECT scope_identity()

COMMIT TRANSACTION
END
