CREATE PROCEDURE [dbo.pragmatic].[spAlerts_Select]

AS
BEGIN
    set nocount on;

    SELECT *
	  FROM [dbo.pragmatic].[Alerts]
END
