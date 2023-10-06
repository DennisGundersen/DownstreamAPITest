CREATE PROCEDURE [dbo.pragmatic].[spOrders_SelectById]
	@Id int

AS

BEGIN
set nocount on;

	select *
	from
		[dbo.pragmatic].[Orders]
	where
		[Id] = @Id
END