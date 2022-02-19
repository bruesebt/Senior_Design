CREATE PROCEDURE [dbo].[spUser_Update]
	@Id INT,
	@Username nvarchar(100),
	@Email nvarchar(200),
	@FirstName nvarchar(100),
	@LastName nvarchar(100), 
	@DateOfBirth DATE,
	@ZipCode varchar(10),
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
		DateAdded = @DateAdded
	WHERE Id = @Id;
END
