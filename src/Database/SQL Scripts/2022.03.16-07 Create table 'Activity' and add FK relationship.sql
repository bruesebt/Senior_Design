/*
   Wednesday, March 16, 202212:29:39 PM
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
CREATE TABLE dbo.Activity
	(
	Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	UserId int NOT NULL,
	PreferenceId int NOT NULL,
	Place_Id nvarchar(255) NOT NULL,
	Name nvarchar(255) NOT NULL,
	DateAdded date NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Activity ADD CONSTRAINT
	FK_Activity_User FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Activity ADD CONSTRAINT
	FK_Activity_Preference FOREIGN KEY
	(
	PreferenceId
	) REFERENCES dbo.[Preference]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Activity SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
