DROP TABLE dbo.[UserRegistrationLog]
GO
CREATE TABLE dbo.[UserRegistrationLog]
(
	[RowId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserLogin] NVARCHAR(90) NOT NULL,
	[IpAdress] NVARCHAR(90) NOT NULL,
	[DateTime] DATETIME DEFAULT GETDATE(),
	[IsSuccess] BIT NOT NULL,
)