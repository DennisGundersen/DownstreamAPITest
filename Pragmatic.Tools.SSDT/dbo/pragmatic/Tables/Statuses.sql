CREATE TABLE [dbo.pragmatic].[Statuses]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Ask] DECIMAL(18, 4) NOT NULL,
	[Bid] DECIMAL(18, 4) NOT NULL,
	[Balance] DECIMAL(18, 2) NOT NULL,
	[Equity] DECIMAL(18, 2) NOT NULL,
	[Margin] DECIMAL(18, 2) NOT NULL,
	[FreeMargin] DECIMAL(18, 2) NOT NULL,
	[Longs] DECIMAL(18, 2) NOT NULL,
	[Shorts] DECIMAL(18, 2) NOT NULL,
	[NextLotSize] DECIMAL(18, 2) NOT NULL,
	[NextLotIncrease] DECIMAL(18, 2) NOT NULL,
	[OrderCount] INT NOT NULL,
	[TradeCountDown] INT NOT NULL,
	[LastUpdated] DATETIME2 NOT NULL,
	[CurrentStep] INT NOT NULL,
	[CurrentTakeProfit] INT NOT NULL,
	[CurrentPipValue] DECIMAL(18, 2) NOT NULL,
	[CurrentLotSize] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_Statuses_Account] FOREIGN KEY ([Id]) REFERENCES [dbo.pragmatic].[Accounts]([Id])
)
