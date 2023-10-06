CREATE TABLE [dbo.pragmatic].[Accounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[AccountNumber] INT NOT NULL,
	[AccountName] NVARCHAR(50) NOT NULL,
	[BrokerName] NVARCHAR(50) NOT NULL,
	[Symbol] CHAR(6) NOT NULL,
	[StepGrowthFactor] DECIMAL(18, 4) NOT NULL,
	[StartingBalance] DECIMAL(18, 2) NOT NULL,
	[StartFactor] INT NOT NULL,
	[Commission] DECIMAL(18, 2) NOT NULL,
	[IsLive] BIT NOT NULL,
	[StrategyId] INT NOT NULL,
	[AccountCurrency] CHAR(3) NOT NULL,
	[RegisteredTime] DATETIME2 NOT NULL, 
	CONSTRAINT [FK_Accounts_Strategies] FOREIGN KEY ([StrategyId]) REFERENCES [dbo.pragmatic].[Strategies]([Id])
)
