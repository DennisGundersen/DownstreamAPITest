CREATE PROCEDURE [dbo.pragmatic].[spStrategies_Insert]
	@Name NVARCHAR(50)
	,@Id INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [dbo.pragmatic].[Strategies]
	(
		[Name]
	)
	OUTPUT INSERTED.*
	VALUES
	(
		@Name
	)
    SET @Id = SCOPE_IDENTITY()
    return @Id;

END