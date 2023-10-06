CREATE PROCEDURE [dbo.pragmatic].[spResults_SelectById]
	@Id int
AS
	
BEGIN
    set nocount on;

    SELECT * FROM [dbo.pragmatic].[Results]
	WHERE [Id] > @Id
END
