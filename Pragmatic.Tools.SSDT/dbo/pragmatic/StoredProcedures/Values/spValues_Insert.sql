CREATE PROCEDURE [dbo.pragmatic].[spValues_Insert]
    @Id int,
	@Name nvarchar(100)

AS
BEGIN
	set nocount on;
	INSERT INTO [dbo.pragmatic].[Values]
	(
        [Name]
	) 
	OUTPUT INSERTED.*
	VALUES 
    (
        @Name
    )
  
 END