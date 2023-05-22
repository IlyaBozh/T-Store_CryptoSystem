CREATE PROCEDURE [dbo].[Transaction_SelectById]
		@Id bigint

AS
BEGIN

	SELECT [Id],
		   [AccountId],
		   [Date],
		   [TransactionType],
		   [Amount],
		   [Currency]
	FROM [dbo].[Transaction]
	WHERE [Id] = @Id
END