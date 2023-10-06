CREATE PROCEDURE [dbo.pragmatic].[spStrategies_Update]
	@Id int,
	@Name nvarchar(50)
AS

BEGIN
SET NOCOUNT ON;

	UPDATE [dbo.pragmatic].[Strategies]
	   SET [Name] = @Name
	 WHERE [Id] = @Id
END
