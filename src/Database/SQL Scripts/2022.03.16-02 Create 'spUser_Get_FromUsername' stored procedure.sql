CREATE PROCEDURE [dbo].[spUser_Get_FromUsername]
	@Username NVARCHAR(100)
AS
BEGIN
	SELECT *
	FROM dbo.[User]
	WHERE Username = @Username;
END