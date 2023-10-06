CREATE PROCEDURE [dbo.pragmatic].[spStatuses_SelectById]
	@Id int
AS

BEGIN
	SET NOCOUNT ON;

	SELECT *
	  FROM [dbo.pragmatic].[Statuses]
	  WHERE [Id] = @Id
END

