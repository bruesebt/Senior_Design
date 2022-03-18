BEGIN TRANSACTION
CREATE TABLE [WhatsTheMove].[dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] nvarchar(100) NOT NULL,
	[Email] nvarchar(200) NOT NULL,
	[FirstName] nvarchar(100) NOT NULL,
	[LastName] nvarchar(100) NOT NULL, 
	[DateOfBirth] DATE NOT NULL,
	[ZipCode] varchar(10) NOT NULL,
	[Password] nvarchar(255) NOT NULL,
	[HashKey] nvarchar(255) NOT NULL,
	[ForgotPasswordKey] nvarchar(255) NULL,
	[IsDarkModePreferred] bit NOT NULL,
	[DateAdded] DATE NOT NULL
)
GO
ALTER TABLE [WhatsTheMove].[dbo].[User] ADD CONSTRAINT
	DF_User_IsDarkModePreferred DEFAULT 0 FOR IsDarkModePreferred
GO
COMMIT
	