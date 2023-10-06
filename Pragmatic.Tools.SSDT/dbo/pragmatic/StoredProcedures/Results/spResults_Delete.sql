CREATE PROCEDURE [dbo.pragmatic].[spResults_DeleteById]
	@Id int
AS
	
BEGIN
    set nocount on;

    DELETE
	FROM [dbo.pragmatic].[Results]
	WHERE [Id] > @Id
END
