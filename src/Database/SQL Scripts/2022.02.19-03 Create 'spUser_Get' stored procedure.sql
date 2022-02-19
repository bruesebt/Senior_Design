CREATE PROCEDURE [dbo].[spUser_Get] 
	@Id INT
AS
BEGIN
	SELECT * 
	FROM dbo.[User]
	WHERE Id = @Id;
END