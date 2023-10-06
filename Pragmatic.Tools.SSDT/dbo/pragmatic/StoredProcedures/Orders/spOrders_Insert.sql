CREATE PROCEDURE [dbo.pragmatic].[spOrders_Insert]
	@Ticket int,
    @OrderType int,
	@Lots decimal(18,2),
	@OpenTime datetime2,
	@CloseTime datetime2,
	@Symbol char(6),
	@OpenRate decimal(18,4),
	@CloseRate decimal(18,4),
	@PlannedOpenRate decimal(18,4),
	@OrderFunction int,
	@StopLossRate decimal(18,4),
	@TakeProfitRate decimal(18,4),
	@Swap decimal(18,2),
	@Commission decimal(18,2),
	@Profit decimal(18,2),
	@Comment varchar(50),
	@AccountId int,
    @Id int output

AS
BEGIN
	set nocount on;

    INSERT INTO [dbo.pragmatic].[Orders] 
	(
        [Ticket]
        ,[OrderType]
        ,[Lots]
        ,[OpenTime]
        ,[CloseTime]
        ,[Symbol]
        ,[OpenRate]
        ,[CloseRate]
        ,[PlannedOpenRate]
        ,[OrderFunction]
        ,[StopLossRate]
        ,[TakeProfitRate]
        ,[Swap]
        ,[Commission]
        ,[Profit]
        ,[Comment]
        ,[AccountId]	
    )
	OUTPUT INSERTED.*
    VALUES 
	(
        @Ticket,
        @OrderType,
        @Lots,
        @OpenTime,
        @CloseTime,
        @Symbol,
        @OpenRate,
        @CloseRate,
        @PlannedOpenRate,
        @OrderFunction,
        @StopLossRate,
        @TakeProfitRate,
        @Swap,
        @Commission,
        @Profit,
        @Comment,
        @AccountId
    )
    
    SET @Id = SCOPE_IDENTITY()
    return @Id;

END
