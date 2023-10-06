CREATE PROCEDURE [dbo.pragmatic].[spOrders_Select]

AS

BEGIN
set nocount on;

	select *
	from
		[dbo.pragmatic].[Orders]
END