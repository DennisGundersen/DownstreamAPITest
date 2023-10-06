CREATE PROCEDURE [dbo.pragmatic].[spOrders_Update]
	@Id int,
	@Ticket int,
	@OrderType int,
	@Lots decimal(18,2),
	@OpenTime datetime2(7),
	@CloseTime datetime,
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
	@Comment varchar(50)

AS

BEGIN
	set nocount on;

	update [dbo.pragmatic].[Orders]
	SET
		[Ticket] = @Ticket,
		[OrderType] = @OrderType,
		[Lots] = @Lots,
		[OpenTime] = @OpenTime,
		[CloseTime] = @CloseTime,
		[Symbol] = @Symbol,
		[OpenRate] = @OpenRate,
		[CloseRate] = @CloseRate,
		[PlannedOpenRate] = @PlannedOpenRate,
		[OrderFunction] = @OrderFunction,
		[StopLossRate] = @StopLossRate,
		[TakeProfitRate] = @TakeProfitRate,
		[Swap] = @Swap,
		[Commission] = @Commission,
		[Profit] = @Profit,
		[Comment] = @Comment
	WHERE
		[Id] = @Id
END
