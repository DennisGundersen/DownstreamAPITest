CREATE PROCEDURE [dbo.pragmatic].[spValues_DeleteById]
	@Id int
AS
BEGIN
	set nocount on;
	
	DELETE
	  FROM [dbo.pragmatic].[Values]
	 WHERE [Id] = @Id
END
