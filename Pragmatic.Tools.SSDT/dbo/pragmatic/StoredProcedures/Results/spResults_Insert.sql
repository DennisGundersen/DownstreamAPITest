CREATE PROCEDURE [dbo.pragmatic].[spResults_Insert]
	@AccountId int,
    @Balance decimal(18,2),
	@Equity decimal(18,2),
	@UsedMargin decimal(18,2),
	--@FreeMargin decimal(18,2),
	@Symbol char(6),
	@Ask decimal(18,4),
	@Bid decimal(18,4),
	@Step int,
	@TradingLotSize decimal(18,2),
	@NextLotSize decimal(18,2),
	@NextIncrease decimal(18,2),
	@Longs decimal(18,2),
	@Shorts decimal(18,2),
	@OrderCount int,
	@ResultTime datetime2,
	@Id int output

AS

BEGIN
	
	set nocount on;
	
	INSERT INTO [dbo.pragmatic].[Results] 
	(
		[AccountId]
           ,[Balance]
           ,[Equity]
           ,[UsedMargin]
           --,[FreeMargin]
           ,[Symbol]
           ,[Ask]
           ,[Bid]
           ,[Step]
           ,[TradingLotSize]
           ,[NextLotSize]
           ,[NextIncrease]
           ,[Longs]
           ,[Shorts]
           ,[OrderCount]
           ,[ResultTime]
	)
	OUTPUT INSERTED.*
	VALUES 
	(
			@AccountId
		   ,@Balance
		   ,@Equity
		   ,@UsedMargin
		   --,@FreeMargin
		   ,@Symbol
		   ,@Ask
		   ,@Bid
		   ,@Step
		   ,@TradingLotSize
		   ,@NextLotSize
		   ,@NextIncrease
		   ,@Longs
		   ,@Shorts
		   ,@OrderCount
		   ,@ResultTime
	)
   
	SET @Id = SCOPE_IDENTITY()
    return @Id;

END