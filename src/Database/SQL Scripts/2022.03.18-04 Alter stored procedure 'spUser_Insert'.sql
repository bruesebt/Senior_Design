/****** Object:  StoredProcedure [dbo].[spUser_Insert]    Script Date: 3/18/2022 12:50:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spUser_Insert]
	@Username nvarchar(100),
	@Email nvarchar(200),
	@FirstName nvarchar(100),
	@LastName nvarchar(100), 
	@DateOfBirth DATE,
	@ZipCode varchar(10),
	@Password nvarchar(255),
	@HashKey nvarchar(255),
	@ForgotPasswordKey nvarchar(255) = NULL,
	@IsDarkModePreferred bit,
	@DateAdded DATE
AS
BEGIN
	INSERT INTO dbo.[User]
		(Username,
		Email,
		FirstName,
		LastName,
		DateOfBirth,
		ZipCode,
		Password,
		HashKey,
		ForgotPasswordKey,
		IsDarkModePreferred,
		DateAdded)
	VALUES
		(@Username,
		@Email,
		@FirstName,
		@LastName,
		@DateOfBirth,
		@ZipCode,
		@Password,
		@HashKey,
		@ForgotPasswordKey,
		@IsDarkModePreferred,
		@DateAdded);
END
