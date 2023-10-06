CREATE PROCEDURE [dbo.pragmatic].[spAlerts_Update]
	@Id int,
    @AccountId int,
    @Rate decimal(18,4),
    @TriggerAbove bit,
    @IsActive bit,
    @UserTag varchar(255),
    @LastUpdated datetime2(7)

AS
BEGIN
    set nocount on;
    UPDATE [dbo.pragmatic].[Alerts]
        SET [Rate] = @Rate,
            [TriggerAbove] = @TriggerAbove,
		    [IsActive] = @IsActive,
		    [UserTag] = @UserTag,
		    [LastUpdated] = @LastUpdated,
		    [AccountId] = @AccountId
	    WHERE [Id] = @Id
END
