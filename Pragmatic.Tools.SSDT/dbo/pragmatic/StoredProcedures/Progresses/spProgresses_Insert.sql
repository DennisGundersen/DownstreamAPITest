CREATE PROCEDURE [dbo.pragmatic].[spProgresses_Insert]
	@AccountId int,
    @Lots decimal(18,2),
    @Steps int,
    @Id int output

AS
BEGIN
	set nocount on;
    INSERT INTO [dbo.pragmatic].[Progresses]
           ([AccountId]
           ,[Lots]
           ,[Steps])
    OUTPUT INSERTED.*
	VALUES
    (
        @AccountId,
        @Lots,
        @Steps
    )

    SET @Id = SCOPE_IDENTITY()
    return @Id;

END