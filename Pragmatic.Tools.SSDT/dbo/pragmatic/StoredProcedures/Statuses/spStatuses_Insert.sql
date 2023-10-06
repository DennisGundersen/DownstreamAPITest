CREATE PROCEDURE [dbo.pragmatic].[spStatuses_Insert]
	@Id int,
    @Ask decimal(18,4),
    @Bid decimal(18,4),
    @Balance decimal(18,2),
    @Equity decimal(18,2),
    @Margin decimal(18,2),
    @FreeMargin decimal(18,2),
    @Longs decimal(18,2),
    @Shorts decimal(18,2),
    @NextLotSize decimal(18,2),
    @NextLotIncrease decimal(18,2),
    @OrderCount int,
    @TradeCountDown int,
    @LastUpdated datetime2,
    @CurrentStep int,
    @CurrentTakeProfit int,
    @CurrentPipValue decimal(18,2),
    @CurrentLotSize decimal(18,2)

AS
BEGIN
	set nocount on;

	INSERT INTO [dbo.pragmatic].[Statuses] 
	(
		    [Id]
           ,[Ask]
           ,[Bid]
           ,[Balance]
           ,[Equity]
           ,[Margin]
           ,[FreeMargin]
           ,[Longs]
           ,[Shorts]
           ,[NextLotSize]
           ,[NextLotIncrease]
           ,[OrderCount]
           ,[TradeCountDown]
           ,[LastUpdated]
           ,[CurrentStep]
           ,[CurrentTakeProfit]
           ,[CurrentPipValue]
           ,[CurrentLotSize]
	)
	OUTPUT INSERTED.*
	VALUES 
	(
		@Id,
        @Ask,
		@Bid,
		@Balance,
		@Equity,
		@Margin,
		@FreeMargin,
		@Longs,
		@Shorts,
		@NextLotSize,
		@NextLotIncrease,
		@OrderCount,
		@TradeCountDown,
		@LastUpdated,
		@CurrentStep,
		@CurrentTakeProfit,
		@CurrentPipValue,
		@CurrentLotSize
	);
END