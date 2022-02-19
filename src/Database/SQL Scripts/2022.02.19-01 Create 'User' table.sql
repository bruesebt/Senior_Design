CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] nvarchar(100) NOT NULL,
	[Email] nvarchar(200) NOT NULL,
	[FirstName] nvarchar(100) NOT NULL,
	[LastName] nvarchar(100) NOT NULL, 
	[DateOfBirth] DATE NOT NULL,
	[ZipCode] varchar(10) NOT NULL,
	[DateAdded] DATE NOT NULL
)
	
	