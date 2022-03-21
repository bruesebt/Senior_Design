CREATE PROCEDURE [dbo].[spUser_Get_FromEmail]
	@Email NVARCHAR(200)
AS
BEGIN
	SELECT *
	FROM dbo.[User]
	WHERE Email = @Email;
END