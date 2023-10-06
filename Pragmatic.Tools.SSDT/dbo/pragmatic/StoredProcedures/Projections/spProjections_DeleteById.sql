CREATE PROCEDURE [dbo.pragmatic].[spProjections_DeleteById]
	@Id int
AS

BEGIN
    set nocount on;
    DELETE
	  FROM [dbo.pragmatic].[Projections]
	  where [Id] = @Id
END