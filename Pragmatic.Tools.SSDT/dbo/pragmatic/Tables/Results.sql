CREATE TABLE [dbo.pragmatic].[Results]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[AccountId] INT NOT NULL,
	[Balance] DECIMAL(18, 2) NOT NULL,
	[Equity] DECIMAL(18, 2) NOT NULL,
	[UsedMargin] DECIMAL(18, 2) NOT NULL
	--,[FreeMargin] DECIMAL(18, 2) NOT NULL
	,[Symbol] CHAR(6) NOT NULL,
	[Ask] DECIMAL(18, 4) NOT NULL,
	[Bid] DECIMAL(18, 4) NOT NULL,
	[Step] INT NOT NULL,
	[TradingLotSize] DECIMAL(18, 2) NOT NULL,
	[NextLotSize] DECIMAL(18, 2) NOT NULL,
	[NextIncrease] DECIMAL(18, 2) NOT NULL,
	[Longs] DECIMAL(18, 2) NOT NULL,
	[Shorts] DECIMAL(18, 2) NOT NULL,
	[OrderCount] INT NOT NULL,
	[ResultTime] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Results_Account] FOREIGN KEY (AccountId) REFERENCES [dbo.pragmatic].[Accounts](Id)
)
