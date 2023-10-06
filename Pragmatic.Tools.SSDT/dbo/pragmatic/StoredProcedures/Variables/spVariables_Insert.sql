CREATE PROCEDURE [dbo.pragmatic].[spVariables_Insert]
	@Id int,
	@TradingLotSize decimal(18,2),  
    @ExtremeTopRate decimal(18,4),
    @NormalTopRate decimal(18,4),
    @CenterRate decimal(18,4),
    @NormalBottomRate decimal(18,4),
    @ExtremeBottomRate decimal(18,4),
    @TestUpToRate decimal(18,4),
    @TestDownToRate decimal(18,4),
    @TestPipsUp int,
    @TestPipsDown int,
    @LongStabilizerSizeFactor decimal(18,4),
    @ShortStabilizerSizeFactor decimal(18,4),
    @LongBalancerSizeFactor decimal(18,4),
    @ShortBalancerSizeFactor decimal(18,4),
    @PrimerSizeFactor decimal(18,4),
    @BalancerStopLossPips int,
    @SecurePips int,
    @AutoLotIncrease bit,
    @AutoLotSafeEQLevel decimal(18,4),
    @TakeProfit int,
    @TradeMidTerm bit,
    @FixedSpread int,
    @ExtraLongBuffer int,
    @ExtraShortBuffer int,
    @WarningLevel int,
    @HeartbeatMonitorTimer int,
    @DatabaseLogTimer int,
    @AutoCloseExtremes bit,
    @RunBalancers bit,
    @RunStabilizers bit,
    @RunBreakouts bit,
    @RunWhiplash bit,
    @RunPrimers bit,
    @GmtOffset int,
    @ScreenshotTimer int,
    @MaxWeight decimal,
    @LastUpdated datetime2

AS
BEGIN
	set nocount on;
	INSERT INTO [dbo.pragmatic].[Variables] 
	(
            [Id]
           ,[TradingLotSize]
           ,[ExtremeTopRate]
           ,[NormalTopRate]
           ,[CenterRate]
           ,[NormalBottomRate]
           ,[ExtremeBottomRate]
           ,[TestUpToRate]
           ,[TestDownToRate]
           ,[TestPipsUp]
           ,[TestPipsDown]
           ,[LongStabilizerSizeFactor]
           ,[ShortStabilizerSizeFactor]
           ,[LongBalancerSizeFactor]
           ,[ShortBalancerSizeFactor]
           ,[PrimerSizeFactor]
           ,[BalancerStopLossPips]
           ,[SecurePips]
           ,[AutoLotIncrease]
           ,[AutoLotSafeEQLevel]
           ,[TakeProfit]
           ,[TradeMidTerm]
           ,[FixedSpread]
           ,[ExtraLongBuffer]
           ,[ExtraShortBuffer]
           ,[WarningLevel]
           ,[HeartbeatMonitorTimer]
           ,[DatabaseLogTimer]
           ,[AutoCloseExtremes]
           ,[RunBalancers]
           ,[RunStabilizers]
           ,[RunBreakouts]
           ,[RunWhiplash]
           ,[RunPrimers]
           ,[GMTOffset]
           ,[ScreenshotTimer]
           ,[MaxWeight]
           ,[LastUpdated]
	)
	OUTPUT INSERTED.*
	VALUES 
	(
        @Id,
        @TradingLotSize,
        @ExtremeTopRate,
        @NormalTopRate,
        @CenterRate,
        @NormalBottomRate,
        @ExtremeBottomRate,
        @TestUpToRate,
        @TestDownToRate,
        @TestPipsUp,
        @TestPipsDown,
        @LongStabilizerSizeFactor,
        @ShortStabilizerSizeFactor,
        @LongBalancerSizeFactor,
        @ShortBalancerSizeFactor,
        @PrimerSizeFactor,
        @BalancerStopLossPips,
        @SecurePips,
        @AutoLotIncrease,
        @AutoLotSafeEQLevel,
        @TakeProfit,
        @TradeMidTerm,
        @FixedSpread,
        @ExtraLongBuffer,
        @ExtraShortBuffer,
        @WarningLevel,
        @HeartbeatMonitorTimer,
        @DatabaseLogTimer,
        @AutoCloseExtremes,
        @RunBalancers,
        @RunStabilizers,
        @RunBreakouts,
        @RunWhiplash,
        @RunPrimers,
        @GmtOffset,
        @ScreenshotTimer,
        @MaxWeight,
        @LastUpdated
	);
END
