DELETE UserInventory
DBCC CHECKIDENT (UserInventory, RESEED, 0);
GO
DELETE GeneralStats
DBCC CHECKIDENT (GeneralStats, RESEED, 0);
GO
DELETE UserEquip
DBCC CHECKIDENT (UserEquip, RESEED, 0);
GO
DELETE [User]
DBCC CHECKIDENT ([User], RESEED, 0);
GO