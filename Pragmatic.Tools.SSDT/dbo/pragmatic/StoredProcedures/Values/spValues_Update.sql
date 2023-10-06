CREATE PROCEDURE [dbo.pragmatic].[spValues_Update]
	@Id int,
    @Name nvarchar(100)
AS
BEGIN
	set nocount on;

    UPDATE [dbo.pragmatic].[Values]
	SET [Name]=@Name
	WHERE [Id] = @Id
END
