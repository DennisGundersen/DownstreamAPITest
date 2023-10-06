CREATE PROCEDURE [dbo.pragmatic].[spOrders_SelectByAccountId]
	@AccountId int

AS

BEGIN
set nocount on;

	select *
	from
		[dbo.pragmatic].[Orders]
	where
		[AccountId] = @AccountId
END