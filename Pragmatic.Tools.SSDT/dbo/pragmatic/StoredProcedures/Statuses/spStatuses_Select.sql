CREATE PROCEDURE [dbo.pragmatic].[spStatuses_Select]
AS

BEGIN
	SET NOCOUNT ON;

	SELECT *
	  FROM [dbo.pragmatic].[Statuses]
END
