-- Testing if Capital letter names can allow sending in models

CREATE PROCEDURE [dbo.pragmatic].[spAccounts_Insert]
	@AccountNumber int,
	@StrategyId int,
    @AccountName nvarchar(50),
    @BrokerName nvarchar(50),
    @Symbol char(6),
    @StepGrowthFactor decimal(18,4),
    @StartingBalance decimal(18,2),
    @StartFactor int,
    @Commission decimal(18,2),
    @IsLive bit,
    @AccountCurrency char(3),
    @RegisteredTime datetime2
    --,@Id int output
AS
BEGIN
	set nocount on;
	INSERT INTO [dbo.pragmatic].Accounts 
	(
        [AccountNumber]
        ,[StrategyId]
        ,[AccountName]
        ,[BrokerName]
        ,[Symbol]
        ,[StepGrowthFactor]
        ,[StartingBalance]
        ,[StartFactor]
        ,[Commission]
        ,[IsLive]
        ,[AccountCurrency]
        ,[RegisteredTime]
	) 
	OUTPUT INSERTED.*
	VALUES 
    (
        @AccountNumber
        ,@StrategyId
        ,@AccountName
        ,@BrokerName
        ,@Symbol
        ,@StepGrowthFactor
        ,@StartingBalance
        ,@StartFactor
        ,@Commission
        ,@IsLive
        ,@AccountCurrency
        ,@RegisteredTime
    )
    
    --SET @Id = SCOPE_IDENTITY()
    --return @Id;
END