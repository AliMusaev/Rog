DROP TABLE dbo.[UserRegistrationLog]
GO
CREATE TABLE dbo.[UserRegistrationLog]
(
	[RowId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserLogin] NVARCHAR(50) NOT NULL,
	[IpAdress] NVARCHAR(50) NOT NULL,
	[DateTime] DATETIME DEFAULT GETDATE(),
	[OpResult] TINYINT NOT NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
)