CREATE PROCEDURE [dbo].[Transaction_AddTransfer]
	@AccountIdSender bigint,
	@AccountIdRecipient bigint,
	@Amount decimal (11,4),
	@AmountConverted decimal (11,4),
	@CurrencySender smallint,
	@CurrencyRecipient smallint
AS
BEGIN 	
BEGIN TRANSACTION

	DECLARE @Date datetime2(7) = sysdatetime()
	DECLARE @TransactionTransfer int = 3

	INSERT INTO [dbo].[Transaction]
	(
		[AccountId], 
		[Date], 
		[TransactionType], 
		[Amount], 
		[Currency]
	)
	VALUES 
	(
		@AccountIdSender,
		@Date,
		@TransactionTransfer,
		@Amount,
		@CurrencySender
	)

	DECLARE @SenderId int= scope_identity() 

	INSERT INTO [dbo].[Transaction]
	( 
		[AccountId], 
		[Date], 
		[TransactionType], 
		[Amount], 
		[Currency]
	)
	VALUES
	(
		@AccountIdRecipient, 
		@Date, 
		@TransactionTransfer, 
		@AmountConverted, 
		@CurrencyRecipient
	)


	DECLARE @actualBalance decimal (11,4)
	SET @actualBalance = (SELECT coalesce(sum([Amount]),0)
						  FROM [dbo].[Transaction] WITH (tablock, holdlock) 
						  WHERE [AccountId] = @AccountIdRecipient)

	IF @actualBalance<0
	ROLLBACK

	ELSE		
		DECLARE @RecipientId int= scope_identity()

	SELECT @SenderId UNION all SELECT @RecipientId

COMMIT TRANSACTION
END