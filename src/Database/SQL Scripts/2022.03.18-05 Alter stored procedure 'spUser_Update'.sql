/****** Object:  StoredProcedure [dbo].[spUser_Update]    Script Date: 3/18/2022 12:55:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spUser_Update]
	@Id INT,
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
	UPDATE dbo.[User]
	SET
		Username = @Username,
		Email = @Email,
		FirstName = @FirstName,
		LastName = @LastName,
		DateOfBirth = @DateOfBirth,
		ZipCode = @ZipCode,
		Password = @Password,
		HashKey = @HashKey,
		ForgotPasswordKey = @ForgotPasswordKey,
		IsDarkModePreferred = @IsDarkModePreferred,
		DateAdded = @DateAdded
	WHERE Id = @Id;
END
