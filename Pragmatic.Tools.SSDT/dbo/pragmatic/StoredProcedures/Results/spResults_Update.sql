CREATE PROCEDURE [dbo.pragmatic].[spResults_Update]
	@Id int,
    @AccountId int,
    @Balance decimal(18,2),
    @Equity decimal(18,2),
    @UsedMargin decimal(18,2),
    --@FreeMargin decimal(18,2),
    @Symbol nvarchar(50),
    @Ask decimal(18,5),
    @Bid decimal(18,5),
    @Step decimal(18,5),
    @TradingLotSize decimal(18,5),
    @NextLotSize decimal(18,5),
    @NextIncrease decimal(18,5),
    @Longs int,
    @Shorts int,
    @OrderCount int,
    @ResultTime datetime

AS
BEGIN
    UPDATE [dbo.pragmatic].[Results]
    SET [AccountId] = @AccountId
	      ,[Balance] = @Balance
	      ,[Equity] = @Equity
	      ,[UsedMargin] = @UsedMargin
	      --,[FreeMargin] = @FreeMargin
	      ,[Symbol] = @Symbol
	      ,[Ask] = @Ask
	      ,[Bid] = @Bid
	      ,[Step] = @Step
	      ,[TradingLotSize] = @TradingLotSize
	      ,[NextLotSize] = @NextLotSize
	      ,[NextIncrease] = @NextIncrease
	      ,[Longs] = @Longs
	      ,[Shorts] = @Shorts
	      ,[OrderCount] = @OrderCount
	      ,[ResultTime] = @ResultTime
    WHERE [Id] = @Id
END