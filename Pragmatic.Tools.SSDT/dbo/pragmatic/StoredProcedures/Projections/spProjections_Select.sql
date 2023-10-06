CREATE PROCEDURE [dbo.pragmatic].[spProjections_Select]
AS

BEGIN
    set nocount on;
    SELECT *
	  FROM [dbo.pragmatic].[Projections]
END