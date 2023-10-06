CREATE PROCEDURE [dbo.pragmatic].[spAccounts_SelectById]
	@Id int
AS
BEGIN
	set nocount on;
	
	SELECT *
	  FROM [dbo.pragmatic].[Accounts]
	 WHERE [Id] = @Id
END
