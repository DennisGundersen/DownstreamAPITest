CREATE PROCEDURE [dbo.pragmatic].[spProgresses_Update]
	@Id int,
	@Lots decimal(18,2),
	@Steps int

AS

BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo.pragmatic].[Progresses]
	SET 
		[Lots] = @Lots,
		[Steps] = @Steps
	WHERE 
		[Id] = @Id
END
