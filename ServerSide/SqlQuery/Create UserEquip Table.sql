CREATE TABLE dbo.UserEquip
(
	UserId INT PRIMARY KEY,
	WeaponId INT NULL,
	SecondWeaponId INT NULL,
	HelmetId INT NULL,
	UpperId INT NULL,
	LowerId INT NULL,
	GlovesId INT NULL,
	ShoesId INT NULL,
	Ring1Id INT NULL,
	Ring2Id INT NULL,
	Earring1Id INT NULL,
	Earring2Id INT NULL,
	AmuletId INT NULL,
	BeltId INT NULL,
	CloakId INT NULL,
	FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
)