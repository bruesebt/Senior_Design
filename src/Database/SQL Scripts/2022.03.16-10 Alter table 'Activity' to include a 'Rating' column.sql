/*
   Wednesday, March 16, 202212:37:54 PM
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
ALTER TABLE dbo.Activity ADD
	Rating int NULL
GO
ALTER TABLE dbo.Activity SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
