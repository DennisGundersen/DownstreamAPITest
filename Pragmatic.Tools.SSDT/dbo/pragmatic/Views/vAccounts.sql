CREATE VIEW [dbo.pragmatic].[vAccounts] AS
	SELECT Accounts.*, Variables.TakeProfit, Variables.NormalTopRate, Variables.NormalBottomRate
	FROM Accounts
	INNER JOIN Variables
	ON [dbo.pragmatic].Accounts.Id = [dbo.pragmatic].Variables.Id;
