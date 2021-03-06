/*
   Friday, March 18, 202212:39:11 PM
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
ALTER TABLE [WhatsTheMove].[dbo].Preference SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE [WhatsTheMove].[dbo].[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE [WhatsTheMove].[dbo].Activity ADD CONSTRAINT
	FK_User_Activity FOREIGN KEY
	(
	UserId
	) REFERENCES [WhatsTheMove].[dbo].[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE [WhatsTheMove].[dbo].Activity ADD CONSTRAINT
	FK_Preference_Activity FOREIGN KEY
	(
	PreferenceId
	) REFERENCES [WhatsTheMove].[dbo].Preference
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE [WhatsTheMove].[dbo].Activity SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
