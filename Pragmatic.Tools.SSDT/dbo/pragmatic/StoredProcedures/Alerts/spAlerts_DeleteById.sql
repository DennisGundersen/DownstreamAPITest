CREATE PROCEDURE [dbo.pragmatic].[spAlerts_DeleteById]
	@Id int
AS
BEGIN
    set nocount on;

    DELETE
	  FROM [dbo.pragmatic].[Alerts]
      WHERE [Id] = @Id
END
