CREATE TABLE [dbo.pragmatic].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Ticket] INT NOT NULL,
	[OrderType] INT NOT NULL,
	[Lots] DECIMAL(18, 2) NOT NULL,
	[OpenTime] DATETIME2 NOT NULL,
	[CloseTime] DATETIME NOT NULL,
	[Symbol] CHAR(6) NOT NULL,
	[OpenRate] DECIMAL(18, 4) NOT NULL,
	[CloseRate] DECIMAL(18, 4) NOT NULL,
	[PlannedOpenRate] DECIMAL(18, 4) NOT NULL,
	[OrderFunction] INT NOT NULL,
	[StopLossRate] DECIMAL(18, 4) NOT NULL,
	[TakeProfitRate] DECIMAL(18, 4) NOT NULL,
	[Swap] DECIMAL(18, 2) NOT NULL,
	[Commission] DECIMAL(18, 2) NOT NULL,
	[Profit] DECIMAL(18, 2) NOT NULL,
	[Comment] VARCHAR(50) NULL,
	[AccountId] INT NOT NULL, 
    CONSTRAINT [FK_Orders_Accounts] FOREIGN KEY ([AccountId]) REFERENCES [dbo.pragmatic].[Accounts]([Id])
)
