CREATE PROCEDURE [dbo.pragmatic].[spProjections_SelectById]
	@Id int
AS

BEGIN
    set nocount on;
    SELECT *
	  FROM [dbo.pragmatic].[Projections]
	  where [Id] = @Id
END