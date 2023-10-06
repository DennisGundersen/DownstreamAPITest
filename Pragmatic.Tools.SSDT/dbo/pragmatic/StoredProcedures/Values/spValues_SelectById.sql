CREATE PROCEDURE [dbo.pragmatic].[spValues_SelectById]
	@Id int
AS
BEGIN
	set nocount on;
	
	SELECT *
	  FROM [dbo.pragmatic].[Values]
	 WHERE [Id] = @Id
END
