CREATE PROCEDURE [dbo.pragmatic].[spProgresses_SelectById]
	@Id int

AS

BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM 
		[dbo.pragmatic].[Progresses]
	WHERE 
		[Id] = @Id
END
