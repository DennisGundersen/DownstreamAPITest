CREATE PROCEDURE [dbo.pragmatic].[spProjections_Insert]
	@Id int,
    @TopRate decimal(18,4),
    @TopEquity decimal(18,2),
    @Steps decimal(18,2),
    @TopLongs decimal(18,2),
    @TopShorts decimal(18,2),
    @BottomRate decimal(18,4),
    @BottomEquity decimal(18,2),
    @BottomBalance decimal(18,2),
    @BottomLongs decimal(18,2),
    @BottomShorts decimal(18,2),
    @UpRate decimal(18,4),
    @UpEquity decimal(18,2),
    @UpBalance decimal(18,2),
    @UpLongs decimal(18,2),
    @UpShorts decimal(18,2),
    @DownRate decimal(18,4),
    @DownEquity decimal(18,2),
    @DownBalance decimal(18,2),
    @DownLongs decimal(18,2),
    @DownShorts decimal(18,2),
    @CenterRate decimal(18,4),
    @CenterEquity decimal(18,2),
    @CenterBalance decimal(18,2),
    @CenterLongs decimal(18,2),
    @CenterShorts decimal(18,2),
    @LastUpdated datetime2

AS
BEGIN
	set nocount on;

    INSERT INTO [dbo.pragmatic].[Projections]
    (
            [Id]
           ,[TopRate]
           ,[TopEquity]
           ,[Steps]
           ,[TopLongs]
           ,[TopShorts]
           ,[BottomRate]
           ,[BottomEquity]
           ,[BottomBalance]
           ,[BottomLongs]
           ,[BottomShorts]
           ,[UpRate]
           ,[UpEquity]
           ,[UpBalance]
           ,[UpLongs]
           ,[UpShorts]
           ,[DownRate]
           ,[DownEquity]
           ,[DownBalance]
           ,[DownLongs]
           ,[DownShorts]
           ,[CenterRate]
           ,[CenterEquity]
           ,[CenterBalance]
           ,[CenterLongs]
           ,[CenterShorts]
           ,[LastUpdated]
    )
     OUTPUT INSERTED.*
	 VALUES
     (
        @Id,
        @TopRate,
        @TopEquity,
        @Steps,
        @TopLongs,
        @TopShorts,
        @BottomRate,
        @BottomEquity,
        @BottomBalance,
        @BottomLongs,
        @BottomShorts,
        @UpRate,
        @UpEquity,
        @UpBalance,
        @UpLongs,
        @UpShorts,
        @DownRate,
        @DownEquity,
        @DownBalance,
        @DownLongs,
        @DownShorts,
        @CenterRate,
        @CenterEquity,
        @CenterBalance,
        @CenterLongs,
        @CenterShorts,
        @LastUpdated
     )
END