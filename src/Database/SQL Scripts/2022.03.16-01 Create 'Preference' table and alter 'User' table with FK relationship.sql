/*
   Wednesday, March 16, 202211:58:28 AM
   User: cargilch
   Server: whatsthemove.database.windows.net
   Database: WhatsTheMove
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Preference
	(
	Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	UserId int NOT NULL,
	GroupSize int NOT NULL,
	IsFoodRequested bit NOT NULL,
	IsDrinksRequested bit NOT NULL,
	EnergyLevel int NOT NULL,
	Budget int NOT NULL,
	TimeOfDay int NOT NULL,
	DressCode int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_GroupSize DEFAULT 0 FOR GroupSize
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_IsFoodRequested DEFAULT 0 FOR IsFoodRequested
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_IsDrinksRequested DEFAULT 0 FOR IsDrinksRequested
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_EnergyLevel DEFAULT 0 FOR EnergyLevel
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_Budget DEFAULT 0 FOR Budget
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_TimeOfDay DEFAULT 0 FOR TimeOfDay
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	DF_Preference_DressCode DEFAULT 0 FOR DressCode
GO
ALTER TABLE dbo.Preference ADD CONSTRAINT
	FK_User_Preference FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
DECLARE @v sql_variant 
SET @v = N'The Id of the User from the User table that this Preference belongs to'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Preference', N'CONSTRAINT', N'FK_User_Preference'
GO
ALTER TABLE dbo.Preference SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
