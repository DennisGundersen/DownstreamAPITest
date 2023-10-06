CREATE PROCEDURE [dbo.pragmatic].[spAlerts_SelectById]
	@Id int
AS
BEGIN
    set nocount on;

    SELECT *
	  FROM [dbo.pragmatic].[Alerts]
      WHERE [Id] = @Id
END
