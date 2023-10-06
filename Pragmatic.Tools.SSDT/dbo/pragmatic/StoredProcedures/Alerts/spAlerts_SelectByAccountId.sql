CREATE PROCEDURE [dbo.pragmatic].[spAlerts_SelectByAccountId]
	@AccountId int
AS
BEGIN
    set nocount on;

    SELECT *
	  FROM [dbo.pragmatic].[Alerts]
      WHERE [AccountId] = @AccountId
END
