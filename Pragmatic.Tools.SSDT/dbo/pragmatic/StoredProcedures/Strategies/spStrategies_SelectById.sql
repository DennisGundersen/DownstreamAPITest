CREATE PROCEDURE [dbo.pragmatic].[spStrategies_SelectById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	  FROM [dbo.pragmatic].[Strategies]
	 WHERE [Id] = @Id
END
