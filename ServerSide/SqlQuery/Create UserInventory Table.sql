CREATE TABLE dbo.[UserInventory]
(
    
	ItemCId INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
	UserId INT NOT NULL,
    ItemTypeId INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
)