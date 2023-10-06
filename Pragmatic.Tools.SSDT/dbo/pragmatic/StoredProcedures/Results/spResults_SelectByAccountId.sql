CREATE PROCEDURE [dbo.pragmatic].[spResults_SelectByAccountId]
	@AccountId int
AS
	
BEGIN
    set nocount on;

    SELECT * FROM [dbo.pragmatic].[Results]
	WHERE [AccountId] > @AccountId
END
