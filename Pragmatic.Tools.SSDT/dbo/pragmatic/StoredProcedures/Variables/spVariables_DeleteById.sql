CREATE PROCEDURE [dbo.pragmatic].[spVariables_DeleteById]
	@Id int
AS
BEGIN
    set nocount on;
    DELETE
	  FROM [dbo.pragmatic].[Variables]
	  WHERE [Id] = @Id
END

