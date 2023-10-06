CREATE PROCEDURE [dbo.pragmatic].[spAccounts_Update]
	@Id int,
    @AccountNumber int,
    @AccountName nvarchar(50),
    @BrokerName nvarchar(50),
    @Symbol char(6),
    @StepGrowthFactor decimal(18,4),
    @StartingBalance decimal(18,2),
    @StartFactor int,
    @Commission decimal(18,2),
    @IsLive bit,
    @StrategyId int,
    @AccountCurrency char(3),
    @RegisteredTime datetime2(7)
AS
BEGIN
	set nocount on;

    UPDATE [dbo.pragmatic].[Accounts]
	   SET [AccountNumber]=@AccountNumber
		  ,[AccountName]=@AccountName
		  ,[BrokerName]=@BrokerName
		  ,[Symbol]=@Symbol
		  ,[StepGrowthFactor]=@StepGrowthFactor
		  ,[StartingBalance]=@StartingBalance
		  ,[StartFactor]=@StartFactor
		  ,[Commission]=@Commission
		  ,[IsLive]=@IsLive
		  ,[StrategyId]=@StrategyId
		  ,[AccountCurrency]=@AccountCurrency
		  ,[RegisteredTime]=@RegisteredTime
	 WHERE [Id] = @Id
END
