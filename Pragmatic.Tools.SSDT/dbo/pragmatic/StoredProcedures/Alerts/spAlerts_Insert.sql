CREATE PROCEDURE [dbo.pragmatic].[spAlerts_Insert]
	@Rate decimal(18,4),
    @TriggerAbove bit,
	@IsActive bit,
	@UserTag varchar(255),
	@LastUpdated datetime2,
	@AccountId int,
    @Id int output

AS
BEGIN
    set nocount on;

	INSERT INTO [dbo.pragmatic].Alerts
           ([Rate]
           ,[TriggerAbove]
           ,[IsActive]
           ,[UserTag]
           ,[LastUpdated]
           ,[AccountId])
     OUTPUT INSERTED.*
	 VALUES
     (
        @Rate
		,@TriggerAbove
		,@IsActive
		,@UserTag
		,@LastUpdated
		,@AccountId
     )
    
    SET @Id = SCOPE_IDENTITY()
    return @Id;

END
