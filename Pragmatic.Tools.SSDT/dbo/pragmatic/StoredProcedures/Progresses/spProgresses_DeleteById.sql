CREATE PROCEDURE [dbo.pragmatic].[spProgresses_DeleteById]
	@Id int

AS

BEGIN
	SET NOCOUNT ON;

	DELETE
	FROM 
		[dbo.pragmatic].[Progresses]
	WHERE 
		[Id] = @Id
END
