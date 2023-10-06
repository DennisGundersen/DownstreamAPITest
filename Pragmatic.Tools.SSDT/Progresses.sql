CREATE TABLE [dbo.pragmatic].[Progresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[AccountId] INT NOT NULL,
	[Lots] DECIMAL(18, 2) NOT NULL,
	[Steps] INT NOT NULL, 
    CONSTRAINT [FK_Progresses_Accounts] FOREIGN KEY ([AccountId]) REFERENCES [dbo.pragmatic].[Accounts]([Id])
)
