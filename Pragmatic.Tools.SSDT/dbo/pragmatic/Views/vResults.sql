CREATE VIEW [dbo.pragmatic].[vResults] AS
	SELECT Id, AccountId, Balance, Equity, UsedMargin, Symbol, Ask, Bid, Step, TradingLotSize, NextLotSize, NextIncrease, Longs, Shorts, OrderCount, ResultTime
	FROM [dbo.pragmatic].Results
	WHERE ResultTime > DATEADD(year, - 2, GETDATE());
