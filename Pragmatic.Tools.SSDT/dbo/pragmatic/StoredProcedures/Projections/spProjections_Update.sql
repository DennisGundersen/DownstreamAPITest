CREATE PROCEDURE [dbo.pragmatic].[spProjections_Update]
    @Id int,
    @TopRate decimal(18, 2),
    @TopEquity decimal(18, 2),
    @Steps int,
    @TopLongs decimal(18, 2),
    @TopShorts decimal(18, 2),
    @BottomRate decimal(18, 2),
    @BottomEquity decimal(18, 2),
    @BottomBalance decimal(18, 2),
    @BottomLongs decimal(18, 2),
    @BottomShorts decimal(18, 2),
    @UpRate decimal(18, 2),
    @UpEquity decimal(18, 2),
    @UpBalance decimal(18, 2),
    @UpLongs decimal(18, 2),
    @UpShorts decimal(18, 2),
    @DownRate decimal(18, 2),
    @DownEquity decimal(18, 2),
    @DownBalance decimal(18,2),
    @DownLongs decimal(18, 2),
    @DownShorts decimal(18, 2),
    @CenterRate decimal(18, 2),
    @CenterEquity decimal(18, 2),
    @CenterBalance decimal(18, 2),
    @CenterLongs decimal(18, 2),
    @CenterShorts decimal(18, 2),
    @LastUpdated datetime

AS

BEGIN
    set nocount on;

    UPDATE [dbo.pragmatic].[Projections]
    SET
		[TopRate] = @TopRate,
		[TopEquity] = @TopEquity,
		[Steps] = @Steps,
		[TopLongs] = @TopLongs,
		[TopShorts] = @TopShorts,
		[BottomRate] = @BottomRate,
		[BottomEquity] = @BottomEquity,
		[BottomBalance] = @BottomBalance,
		[BottomLongs] = @BottomLongs,
		[BottomShorts] = @BottomShorts,
		[UpRate] = @UpRate,
		[UpEquity] = @UpEquity,
		[UpBalance] = @UpBalance,
		[UpLongs] = @UpLongs,
		[UpShorts] = @UpShorts,
		[DownRate] = @DownRate,
		[DownEquity] = @DownEquity,
		[DownBalance] = @DownBalance,
		[DownLongs] = @DownLongs,
		[DownShorts] = @DownShorts,
		[CenterRate] = @CenterRate,
		[CenterEquity] = @CenterEquity,
		[CenterBalance] = @CenterBalance,
		[CenterLongs] = @CenterLongs,
		[CenterShorts] = @CenterShorts,
		[LastUpdated] = @LastUpdated
	WHERE
		[Id] = @Id
END