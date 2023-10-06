CREATE PROCEDURE [dbo.pragmatic].[spAccounts_DeleteById]
	@Id int
AS
BEGIN
	set nocount on;
	
	DELETE
	  FROM [dbo.pragmatic].[Accounts]
	 WHERE [Id] = @Id
END
