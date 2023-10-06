CREATE PROCEDURE [dbo.pragmatic].[spVariables_Update]
	@Id int
    ,@TradingLotSize decimal(18,2)
    ,@ExtremeTopRate decimal(18,4)
    ,@NormalTopRate decimal(18,4)
    ,@CenterRate decimal(18,4)
    ,@NormalBottomRate decimal(18,4)
    ,@ExtremeBottomRate decimal(18,4)
    ,@TestUpToRate decimal(18,4)
    ,@TestDownToRate decimal(18,4)
    ,@TestPipsUp int
    ,@TestPipsDown int
    ,@LongStabilizerSizeFactor int
    ,@ShortStabilizerSizeFactor int
    ,@LongBalancerSizeFactor int
    ,@ShortBalancerSizeFactor int
    ,@PrimerSizeFactor int
    ,@BalancerStopLossPips int
    ,@SecurePips int
    ,@AutoLotIncrease bit
    ,@AutoLotSafeEQLevel int
    ,@TakeProfit int
    ,@TradeMidTerm bit
    ,@FixedSpread int
    ,@ExtraLongBuffer int
    ,@ExtraShortBuffer int
    ,@WarningLevel int
    ,@HeartbeatMonitorTimer int
    ,@DatabaseLogTimer int
    ,@AutoCloseExtremes bit
    ,@RunBalancers bit
    ,@RunStabilizers bit
    ,@RunBreakouts bit
    ,@RunWhiplash bit
    ,@RunPrimers bit
    ,@GMTOffset int

AS
    
BEGIN
    set nocount on;

    UPDATE [dbo.pragmatic].[Variables]
        SET [TradingLotSize] = @TradingLotSize
			,[ExtremeTopRate] = @ExtremeTopRate
			,[NormalTopRate] = @NormalTopRate
			,[CenterRate] = @CenterRate
			,[NormalBottomRate] = @NormalBottomRate
			,[ExtremeBottomRate] = @ExtremeBottomRate
			,[TestUpToRate] = @TestUpToRate
			,[TestDownToRate] = @TestDownToRate
			,[TestPipsUp] = @TestPipsUp
			,[TestPipsDown] = @TestPipsDown
			,[LongStabilizerSizeFactor] = @LongStabilizerSizeFactor
			,[ShortStabilizerSizeFactor] = @ShortStabilizerSizeFactor
			,[LongBalancerSizeFactor] = @LongBalancerSizeFactor
			,[ShortBalancerSizeFactor] = @ShortBalancerSizeFactor
			,[PrimerSizeFactor] = @PrimerSizeFactor
			,[BalancerStopLossPips] = @BalancerStopLossPips
			,[SecurePips] = @SecurePips
			,[AutoLotIncrease] = @AutoLotIncrease
			,[AutoLotSafeEQLevel] = @AutoLotSafeEQLevel
			,[TakeProfit] = @TakeProfit
			,[TradeMidTerm] = @TradeMidTerm
			,[FixedSpread] = @FixedSpread
			,[ExtraLongBuffer] = @ExtraLongBuffer
			,[ExtraShortBuffer] = @ExtraShortBuffer
			,[WarningLevel] = @WarningLevel
			,[HeartbeatMonitorTimer] = @HeartbeatMonitorTimer
			,[DatabaseLogTimer] = @DatabaseLogTimer
			,[AutoCloseExtremes] = @AutoCloseExtremes
			,[RunBalancers] = @RunBalancers
			,[RunStabilizers] = @RunStabilizers
			,[RunBreakouts] = @RunBreakouts
			,[RunWhiplash] = @RunWhiplash
			,[RunPrimers] = @RunPrimers
			,[GMTOffset] = @GMTOffset
    WHERE [Id] = @Id
END