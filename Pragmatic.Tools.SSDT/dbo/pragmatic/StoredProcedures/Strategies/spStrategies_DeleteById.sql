CREATE PROCEDURE [dbo.pragmatic].[spStrategies_DeleteById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE
	  FROM [dbo.pragmatic].[Strategies]
	 WHERE [Id] = @Id
END
