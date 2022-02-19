CREATE PROCEDURE [dbo].[spUser_Insert]
	@Username nvarchar(100),
	@Email nvarchar(200),
	@FirstName nvarchar(100),
	@LastName nvarchar(100), 
	@DateOfBirth DATE,
	@ZipCode varchar(10),
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
		DateAdded)
	VALUES
		(@Username,
		@Email,
		@FirstName,
		@LastName,
		@DateOfBirth,
		@ZipCode,
		@DateAdded);
END
