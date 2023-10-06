CREATE PROCEDURE [dbo.pragmatic].[spStatuses_Update]
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
    @LastUpdated datetime2(7),
    @CurrentStep int,
    @CurrentTakeProfit int,
    @CurrentPipValue decimal(18,2),
    @CurrentLotSize decimal(18,2)

AS
BEGIN
    UPDATE [dbo.pragmatic].[Statuses]
	   SET [Id] = @Id
		  ,[Ask] = @Ask
		  ,[Bid] = @Bid
		  ,[Balance] = @Balance
		  ,[Equity] = @Equity
		  ,[Margin] = @Margin
		  ,[FreeMargin] = @FreeMargin
		  ,[Longs] = @Longs
		  ,[Shorts] = @Shorts
		  ,[NextLotSize] = @NextLotSize
		  ,[NextLotIncrease] = @NextLotIncrease
		  ,[OrderCount] = @OrderCount
		  ,[TradeCountDown] = @TradeCountDown
		  ,[LastUpdated] = @LastUpdated
		  ,[CurrentStep] = @CurrentStep
		  ,[CurrentTakeProfit] = @CurrentTakeProfit
		  ,[CurrentPipValue] = @CurrentPipValue
		  ,[CurrentLotSize] = @CurrentLotSize
	 WHERE [Id] = @id
END