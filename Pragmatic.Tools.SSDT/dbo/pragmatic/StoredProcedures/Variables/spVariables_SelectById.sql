CREATE PROCEDURE [dbo.pragmatic].[spVariables_SelectById]
	@Id int
AS
BEGIN
    set nocount on;
    SELECT *
	  FROM [dbo.pragmatic].[Variables]
	  WHERE [Id] = @Id
END

