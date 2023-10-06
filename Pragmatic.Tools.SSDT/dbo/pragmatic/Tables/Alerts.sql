CREATE TABLE [dbo.pragmatic].[Alerts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Rate] DECIMAL (18, 4) NOT NULL,
	[TriggerAbove] BIT NOT NULL,
	[IsActive] BIT NOT NULL,
	[UserTag] VARCHAR(255) NOT NULL,
	[LastUpdated] DATETIME2 NOT NULL,
	[AccountId] INT NOT NULL, 
    CONSTRAINT [FK_Alerts_Accounts] FOREIGN KEY ([AccountId]) REFERENCES [dbo.pragmatic].[Accounts]([Id])
)
