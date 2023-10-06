CREATE PROCEDURE [dbo.pragmatic].[spStatuses_DeleteById]
	@Id int
AS

BEGIN
	SET NOCOUNT ON;

	DELETE
	  FROM [dbo.pragmatic].[Statuses]
	  WHERE [Id] = @Id
END

