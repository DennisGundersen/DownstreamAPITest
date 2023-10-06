CREATE PROCEDURE [dbo.pragmatic].[spAccounts_Select]
AS
BEGIN
	set nocount on;
	
	SELECT *
	  FROM [dbo.pragmatic].[Accounts]
END
